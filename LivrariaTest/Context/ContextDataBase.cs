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

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livros> Livro { get; set; }
    }
}
