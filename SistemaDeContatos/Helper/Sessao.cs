using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Helper
{
    public class Sessao : ISessao
    {
        //Esta variável permite a funcionalidade da sessão. Com ela é feita a injeção de dependência.
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }   

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            //A SetString exige como parâmetro chave e valor da sessão, ambas como string.
            //Por exigir o valor como string, deve ser feita a conversão do objeto usuario para string em json - serializar o objeto usuário.
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //Se vier vazio
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            //Deserializar o objeto
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }
    }
}
