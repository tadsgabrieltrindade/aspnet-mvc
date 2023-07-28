﻿using SistemaDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeContatos.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Login obrigatório!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string Senha { get; set; }
    }
}
