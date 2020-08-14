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

        [Required(ErrorMessage = "Nome do autor é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome do autor deve ter entre 3 e 30 caracteres")]
        public string Nome { get; set; }

        public virtual List<Livros> Livros { get; set; }
    }
}
