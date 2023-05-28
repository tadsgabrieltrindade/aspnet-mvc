using SistemaDeContatos.Models;
using System.Collections.Generic;

namespace SistemaDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);

        List<ContatoModel> BuscarTodosContatos();

        ContatoModel BuscarPorId(int id);

        void apagarContatoPorId(int id);

        void atualizarContato(ContatoModel contato, int id);
    }
}
