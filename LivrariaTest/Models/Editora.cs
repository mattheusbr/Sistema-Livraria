using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Models
{
    [Table("Mt_Editora")]
    public class Editora
    {
        [Key]
        public int IdEditora { get; set; }

        [Required(ErrorMessage = "Nome da editora é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome da editora deve ter entre 3 e 30 caracteres")]
        public string Nome { get; set; }
        public List<Livros> Livros { get; set; }
    }
}
