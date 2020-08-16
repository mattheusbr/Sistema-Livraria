using LivrariaTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaTest.Context
{
    public class ContextDataBase : DbContext
    {
        public ContextDataBase(DbContextOptions<ContextDataBase> options) : base(options)
        {
        }

        public DbSet<Models.Autor> Autor { get; set; }
        public DbSet<Models.Editora> Editora { get; set; }
        public DbSet<Models.Livro> Livro { get; set; }
        public DbSet<Models.Usuario> Usuario { get; set; }
    }
}
