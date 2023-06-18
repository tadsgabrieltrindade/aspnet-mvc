using System.ComponentModel.DataAnnotations;

namespace SistemaDeContatos.Models
{
    public class ContatoModel  
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nome do contato obrigatório!")]
        public string nome { get; set; }

        [Required(ErrorMessage = "E-mail do contato obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido! Por favor, tente novamente.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Celular do contato obrigatório!")]
        [Phone(ErrorMessage = "Número inválido! Por favor, tente novamente.")]
        public string celular { get; set; }
    }
}
