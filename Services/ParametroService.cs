using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class ParametroService : IParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IAquarioRepository _aquarioRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IAlertaRepository _alertaRepository;

        public ParametroService(IParametroRepository parametroRepository, IAquarioRepository aquarioRepository,
            IHistoricoRepository historicoRepository, IUsuarioService usuarioService,
            IAlertaRepository alertaRepository)
        {
            _parametroRepository = parametroRepository;
            _aquarioRepository = aquarioRepository;
            _historicoRepository = historicoRepository;
            _usuarioService = usuarioService;
            _alertaRepository = alertaRepository;
        }

        public void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro)
        {
            var parametro = _parametroRepository.BuscarParametroPorTipo(novoAquarioParametro.TipoParametro);
            var aquario = _aquarioRepository.RecuperarPorId(novoAquarioParametro.IdAquario);

            if (parametro == null)
            {
                throw new NotFoundException("Parâmetro não encontrado.");
            }

            if (aquario == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            AquarioParametro aquarioParametro = new AquarioParametro
            {
                AquariosId = novoAquarioParametro.IdAquario,
                Valor = novoAquarioParametro.Valor,
                ParametrosId = parametro.Id
            };

            _parametroRepository.AdicionarParametroAoAquario(aquarioParametro);
            _parametroRepository.SaveChanges();
        }

        public void ExcluirParametroDoAquario(int idAquario, int idAquarioParametro)
        {
            var aquarioParametro = _parametroRepository.BuscarAquarioParametro(idAquarioParametro);

            if (aquarioParametro == null)
            {
                throw new NotFoundException("Parâmetro não encontrado no aquário.");
            }

            _parametroRepository.ExcluirParametroDoAquario(aquarioParametro);
            _parametroRepository.SaveChanges();
        }

        public List<AquarioParametro> ParametrosDoAquario(int idAquario)
        {
            return _parametroRepository.ParametrosDoAquario(idAquario);
        }

        public void AtualizarValorAquarioParametro(int idAquarioParametro, int valor)
        {
            AquarioParametro? aquarioParametro = _parametroRepository.BuscarAquarioParametro(idAquarioParametro);
            if (aquarioParametro == null)
            {
                throw new NotFoundException("Não foi possível localizar esse parâmetro.");
            }

            if (aquarioParametro.Valor == valor)
            {
                return;
            }

            aquarioParametro.Valor = valor;

            _parametroRepository.AtualizarParametro(aquarioParametro);

            Usuario usuarioAutenticado = _usuarioService.RecuperarUsuarioAutenticado();

            Historico historico = new Historico();
            historico.Valor = valor;
            historico.Usuario = usuarioAutenticado;
            historico.Hora = DateTime.Now;
            historico.AquarioParametro = aquarioParametro;

            List<Alerta> alertas = _alertaRepository.BuscarAlertaPeloIdAquarioParametro(aquarioParametro.Id);
            foreach (var alerta in alertas)
            {
                alerta.EstadoAlerta = VerificarEstadoAlerta(valor, alerta.Min, alerta.Max);
                _alertaRepository.AlterarAlerta(alerta);
            }

            _historicoRepository.InserirHistorico(historico);
            _parametroRepository.SaveChanges();
            _alertaRepository.SaveChanges();
            _historicoRepository.SaveChanges();
        }

        public List<Historico> BuscarHistoricoAquarioParametro(int idAquarioParametro)
        {
            DateTime dataLimite = DateTime.Now.AddHours(-24);
            return _historicoRepository.BuscarUltimosHistoricoAquarioParametro(idAquarioParametro, dataLimite);
        }

        private EstadoAlerta VerificarEstadoAlerta(double valor, double min, double max)
        {
            if (valor <= min || valor >= max)
            {
                return EstadoAlerta.Vermelho;
            }

            if ((valor - min) / (max - min) <= 0.05 || (max - valor) / (max - min) <= 0.05)
            {
                return EstadoAlerta.Vermelho;
            }

            if ((valor - min) / (max - min) <= 0.1 || (max - valor) / (max - min) <= 0.1)
            {
                return EstadoAlerta.Amarelo;
            }

            return EstadoAlerta.Verde;
        }
    }
}