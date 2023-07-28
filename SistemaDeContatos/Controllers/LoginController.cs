using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Helper;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositorio;

namespace SistemaDeContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _repositorio;
        
        //Utilização da sessão
        private readonly ISessao _sessao;


        public LoginController(IUsuarioRepositorio repositorio, ISessao sessao)
        {
            _repositorio = repositorio;
            _sessao = sessao;
        }


        public IActionResult Index()
        {
            //Se o usuário já estiver logado, a aplicação deve redirecionar para Home
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel _login)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _repositorio.BuscarPorLogin(_login);

                    if (usuario != null)
                    {
                       if(_login.verificarSenha(usuario, _login.Senha)){
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
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
