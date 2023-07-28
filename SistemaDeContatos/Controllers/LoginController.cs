using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositorio;

namespace SistemaDeContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _repositorio;


        public LoginController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel _login)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    if(_repositorio.LoginUsuario(_login.Login, _login.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["MensagemErro"] = $"Erro ao fazer login, verifique suas credenciais!";
                    return View("Index");
                }

                return View("Index");

            }
            catch (System.Exception err)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login. Tente novamente! \nDetalhes do erro: {err.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
