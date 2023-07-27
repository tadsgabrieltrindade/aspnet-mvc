using SistemaDeContatos.Models;
using System.Collections.Generic;

namespace SistemaDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel contato);

        List<UsuarioModel> BuscarTodosUsuarios();

        UsuarioModel BuscarPorId(int id);

        void apagarUsuarioPorId(int id);

        void atualizarUsuario(UsuarioModel usuario);
    }
}
