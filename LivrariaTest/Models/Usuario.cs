using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Models
{
    public class Usuario
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return new List<Usuario>() {
              new Usuario {
                Id = 1,
                Login = "Admin",
                Senha = "Admin"
              }
            };
        }

    }
}
