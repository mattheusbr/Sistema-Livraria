using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Models
{
    [Table("Mt_Livros")]
    public class Livro
    {
        [Key]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "Código do livro é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Nome do livro deve ter entre 3 e 30 caracteres")]
        public string Nome { get; set; }

        [ForeignKey("Autor")]
        public virtual Autor Fk_Autor { get; set; }

        public int Autor { get; set; }

        [ForeignKey("Editora")]
        public virtual Editora Fk_Editora { get; set; }
        public int Editora { get; set; }

    }
}
