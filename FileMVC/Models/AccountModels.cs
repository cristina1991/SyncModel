using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace FileMVC.Models
{

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Nume Utilizator")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Curenta")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} trebuie sa contina cel putin {2} caractere lungime.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Noua")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Parola Noua")]
        [Compare("NewPassword", ErrorMessage = "Parola noua nu coincide cu parola de confirmare.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Nume Utilizator")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Retine!")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Nume Utilizator")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} trebuie sa contina cel putin {2} caractere lungime.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Parola")]
        [Compare("Password", ErrorMessage = "Parola noua nu coincide cu parola de confirmare.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
