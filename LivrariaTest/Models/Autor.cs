using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Models
{
    [Table("Mt_Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "Nome do(a) Autor(a) é obrigatório")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Nome do(a) Autor(a) deve ter entre 5 e 40 caracteres")]
        public string Nome { get; set; }
        public virtual List<Livro> Livros { get; set; }
    }
}
