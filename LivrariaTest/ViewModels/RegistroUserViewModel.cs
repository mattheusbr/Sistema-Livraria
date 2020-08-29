using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.ViewModels
{
    public class RegistroUserViewModel
    {
/*        [Required(ErrorMessage = "Obrigatorio o preenchimento do Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio o preenchimento do Sobrenome")]
        public string Sobrenome { get; set; }*/

        [Required(ErrorMessage = "Obrigatorio o preenchimento do Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio o preenchimento da Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
            
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string CorfimarSenha { get; set; }
    }
}
