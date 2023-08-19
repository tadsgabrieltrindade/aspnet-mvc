using System.Security.Cryptography;
using System.Text;

namespace SistemaDeContatos.Helper.Criptografia
{
    public static class CriptografiaHash
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            var strHexa = new StringBuilder();

            foreach(var item in array )
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();

        }

    }
}
