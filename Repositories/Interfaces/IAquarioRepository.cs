﻿using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IAquarioRepository
    {
        Aquario Inserir(Aquario aquario);
        Task<Aquario> Alterar(Aquario aquario);
        void Excluir(Aquario aquario);
        Aquario? RecuperarPorId(int id);
        List<Aquario> RecuperarPorUsuarioId(int id, string? nomeAquario);
    }
}
