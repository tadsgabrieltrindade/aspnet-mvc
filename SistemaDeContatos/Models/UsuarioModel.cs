using SistemaDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeContatos.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Login obrigatório! Digite um que deseja.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string Senha { get; set; }
        [Required()]
        [EmailAddress(ErrorMessage = "E-mail inválido! Por favor, tente novamente.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Perfil obrigatório!")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }

        //? indica que o campo pode ser nulo
        public DateTime? DataAlteracao { get; set; }


        public UsuarioModel()
        {
            this.DataCadastro = DateTime.Now;
            this.DataAlteracao = DateTime.Now;
        }
    }
}
