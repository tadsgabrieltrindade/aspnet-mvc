using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Enums;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositorio;
using System;
using System.Collections.Generic;

namespace SistemaDeContatos.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _repositorio;
        

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            usuarios = _repositorio.BuscarTodosUsuarios();
            
            return View(usuarios);
        }

        public IActionResult Criar()
        {
          

            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                //O ModelState.IsValid serve para verificar se todos os dados estão conforme requerido. 
                if (ModelState.IsValid)
                {
                   
                    _repositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (System.Exception err)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o usuário. Tente novamente! \nDetalhes do erro: {err.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult Editar(int id)
        {
           
            UsuarioModel usuario = new UsuarioModel();
            usuario = _repositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            UsuarioModel usuario = null;
            usuario = new UsuarioModel()
            {
                id = usuarioSemSenha.id,
                Nome = usuarioSemSenha.Nome,
                Login = usuarioSemSenha.Login,
                Email = usuarioSemSenha.Email,
                Perfil = usuarioSemSenha.Perfil
            };

            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.atualizarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
                 

            }
            catch (System.Exception err)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos editar o usuário. Tente novamente! \nDetalhes do erro: {err.Message}";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario = _repositorio.BuscarPorId(id);
            return View(usuario);
        }


        public IActionResult Apagar(int id)
        {
            try
            {
                _repositorio.apagarUsuarioPorId(id);
                TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Ops! Erro ao excluir usuário. Por favor, tente novamente! \nDetalhe do erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
