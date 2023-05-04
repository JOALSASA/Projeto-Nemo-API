﻿using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto cadastrarNovoUsuario(NovoUsuarioForm novoUsuario);
        Usuario Inserir(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        Usuario Excluir(Usuario usuario);
        UsuarioDto FindUsuarioById(int id);
        List<UsuarioDto> FindUsuarioByNome(string nome);
    }
}
