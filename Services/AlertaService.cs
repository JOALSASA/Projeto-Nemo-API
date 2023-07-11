using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IAquarioRepository _aquarioRepository;
        private readonly IAlertaRepository _alertaRepository;

        public AlertaService(IParametroRepository parametroRepository, IAquarioRepository aquarioRepository, IAlertaRepository alertaRepository)
        {
            _parametroRepository = parametroRepository;
            _aquarioRepository = aquarioRepository;
            _alertaRepository = alertaRepository;
        }

        public void AdicionarAlerta(NovoAlertaForm novoAlertaForm)
        {
            var aquarioParametro = _parametroRepository.BuscarAquarioParametro(novoAlertaForm.AquarioParametroId);
            var aquario = _aquarioRepository.RecuperarPorId(novoAlertaForm.AquarioId);
            
            if (aquarioParametro == null)
            {
                throw new NotFoundException("Parâmetro não encontrado.");
            }
            
            if (aquario == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            Alerta novoAlerta = new Alerta
            {
                Nome = novoAlertaForm.Nome,
                Min = novoAlertaForm.Min,
                Max = novoAlertaForm.Max,
                EstadoAlerta = EstadoAlerta.Verde,
                Aquario = aquario,
                AquarioParametro = aquarioParametro
            };

            _alertaRepository.AdicionarAlerta(novoAlerta);
        }

        public List<Alerta> ConsultarTodosOsAlertas()
        {
            return _alertaRepository.ConsultarTodosOsAlertas();
        }

        public List<Alerta> ConsultarAlertasDoAquario(int idAquario)
        {
            return _alertaRepository.ConsultarAlertasDoAquario(idAquario);
        }

        public void AlterarAlerta(int idAlerta ,NovoAlertaForm novoAlertaForm)
        {
            Alerta alertaAntigo = _alertaRepository.BuscarAlertaPeloId(idAlerta);
            if (alertaAntigo == null)
            {
                throw new NotFoundException("Alerta não encontrado.");
            }

            alertaAntigo.Nome = novoAlertaForm.Nome;
            alertaAntigo.Max = novoAlertaForm.Max;
            alertaAntigo.Min = novoAlertaForm.Min;

            _alertaRepository.AlterarAlerta(alertaAntigo);
        }

        public void ExcluirAlertaDoAquario(int idAlerta)
        {
            var alerta = _alertaRepository.BuscarAlertaPeloId(idAlerta);
            if (alerta == null)
            {
                throw new NotFoundException("Alerta não encontrado.");
            }

            _alertaRepository.ExcluirAlertaDoAquario(alerta);
        }
    }
}

