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
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.atualizarContato(contato, id);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);


            }
            catch (System.Exception err)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos editar seu contato. Tente novamente! \nDetalhes do erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = new ContatoModel();
            contato = _repositorio.BuscarPorId(id);
            return View(contato);
        }
         

        public IActionResult Apagar(int id)
        {
            try
            {
                _repositorio.apagarContatoPorId(id);
                TempData["MensagemSucesso"] = "Contato excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch(System.Exception err)
            {
                TempData["MensagemErro"] = $"Ops! Erro ao excluir contato. Por favor, tente novamente! \nDetalhe do erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                //O ModelState.IsValid serve para verificar se todos os dados estão conforme requerido. 
                if (ModelState.IsValid)
                {
                    _repositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (System.Exception err)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato. Tente novamente! \nDetalhes do erro: {err.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
