using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositorio;
using System.Collections.Generic;

namespace SistemaDeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _repositorio;

        public ContatoController(IContatoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = new List<ContatoModel>();
            contatos = _repositorio.BuscarTodosContatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = new ContatoModel();
            contato = _repositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult EditarConfirmacao(ContatoModel contato, int id)
        {
            _repositorio.atualizarContato(contato, id);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = new ContatoModel();
            contato = _repositorio.BuscarPorId(id);
            return View(contato);
        }


        public IActionResult Apagar(int id)
        {
            _repositorio.apagarContatoPorId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _repositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
