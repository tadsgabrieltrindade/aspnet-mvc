using SistemaDeContatos.Models;
using System.Collections.Generic;

namespace SistemaDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);

        List<UsuarioModel> BuscarTodosUsuarios();

        UsuarioModel BuscarPorId(int id);

        void apagarUsuarioPorId(int id);
        UsuarioModel BuscarPorLogin(LoginModel _login);
        void atualizarUsuario(UsuarioModel usuario);

    }
}
