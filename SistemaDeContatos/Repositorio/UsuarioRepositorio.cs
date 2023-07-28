using SistemaDeContatos.Data;
using SistemaDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Gravar no banco de dados
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public void apagarUsuarioPorId(int id)
        {

            UsuarioModel usuario = _bancoContext.Usuarios.Single(x => x.id == id);
            if (usuario == null) throw new System.Exception("Houve um erro ao apagar contato!");

            _bancoContext.Usuarios.Remove(usuario);
            _bancoContext.SaveChanges();

        }

        public void atualizarUsuario(UsuarioModel _usuario)
        {
            if(_usuario != null)
            {
                int id = _usuario.id;
                UsuarioModel usuario = _bancoContext.Usuarios.Single(x => x.id == id);
                if (usuario == null) throw new System.Exception("Houve um erro ao apagar contato!");
                usuario.Nome = _usuario.Nome;
                usuario.Email = _usuario.Email;
                usuario.Login = _usuario.Login;
                usuario.Perfil = _usuario.Perfil;
                //usuario.DataCadastro = usuario.DataCadastro;
                usuario.DataAlteracao = DateTime.Now;

                _bancoContext.SaveChanges();
            }
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuarios.Single(x => x.id == id);
        }

        public List<UsuarioModel> BuscarTodosUsuarios()
        {
            return  _bancoContext.Usuarios.ToList();
        }

        public bool LoginUsuario(string login, string senha)
        {
            if (login != null && senha != null)
            {
                var resultado = _bancoContext.Usuarios
                    .SingleOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Senha == senha);

                if (resultado != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
