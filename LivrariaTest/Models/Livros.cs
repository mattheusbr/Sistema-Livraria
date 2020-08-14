using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Models
{
    [Table("Mt_Livros")]
    public class Livros
    {
        [Key]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "Nome do livro é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome do livro deve ter entre 3 e 30 caracteres")]
        public string Nome { get; set; }

        [ForeignKey("Mt_Autor")]
        public virtual Autor IdAutor { get; set; }
        public int Autor { get; set; }

        [ForeignKey("Mt_Editora")]
        public virtual Editora IdEditora { get; set; }
        public int Editora { get; set; }

        [StringLength(700)]
        public string Descricao { get; set; }

    }
}
