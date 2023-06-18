using SistemaDeContatos.Data;
using SistemaDeContatos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public void apagarContatoPorId(int id)
        {

            ContatoModel contato = _bancoContext.Contatos.Single(x => x.id == id);
            if (contato == null) throw new System.Exception("Houve um erro ao apagar contato!");

            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges();

        }

        public void atualizarContato(ContatoModel _contato, int id)
        {
            if(_contato != null)
            {
                ContatoModel contato = _bancoContext.Contatos.Single(x => x.id == id);
                if (contato == null) throw new System.Exception("Houve um erro ao apagar contato!");
                contato.nome = _contato.nome;
                contato.email = _contato.email;
                contato.celular = _contato.celular;

                _bancoContext.SaveChanges();
            }
        }

        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.Single(x => x.id == id);
        }

        public List<ContatoModel> BuscarTodosContatos()
        {
            return  _bancoContext.Contatos.ToList();
        }
    }
}
