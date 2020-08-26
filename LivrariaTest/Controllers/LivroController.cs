using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivrariaTest.Context;
using LivrariaTest.Models;
using LivrariaTest.Migrations;
using LivrariaTest.Log;

namespace LivrariaTest.Controllers
{
    public class LivroController : Controller 
    {
        private readonly ContextDataBase _context;
        SistemaLog sistemaLog = new SistemaLog();

        public LivroController(ContextDataBase context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            var contextDataBase = _context.Livro.Include(l => l.Fk_Autor).Include(l => l.Fk_Editora);
            return View(await contextDataBase.ToListAsync());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Fk_Autor)
                .Include(l => l.Fk_Editora)
                .FirstOrDefaultAsync(m => m.IdLivro == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["Autor"] = new SelectList(_context.Autor, "IdAutor", "Nome");
            ViewData["Editora"] = new SelectList(_context.Editora, "IdEditora", "Nome");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLivro,Codigo,Nome,Autor,Editora")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                //Remover espaços em branco extra
                livro.Codigo.Trim();
                livro.Nome.Trim();

                if ((_context.Livro.Where(x => x.Codigo == livro.Codigo).Count() > 0) ||
                    (_context.Livro.Where(x => x.Nome == livro.Nome).Count() >0))
                {
                    ViewBag.Message = "*Já existe um livro cadastrado com esses dados";
                }
                else
                {
                    _context.Add(livro);
                    await _context.SaveChangesAsync();
                    var codigo_livro = livro.Codigo;
                    sistemaLog.criarLog("Gerenciamento de livros", "Adicionou", $"Livro(código: {codigo_livro})");
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Autor"] = new SelectList(_context.Autor, "IdAutor", "Nome", livro.Autor);
            ViewData["Editora"] = new SelectList(_context.Editora, "IdEditora", "Nome", livro.Editora);
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["Autor"] = new SelectList(_context.Autor, "IdAutor", "Nome", livro.Autor);
            ViewData["Editora"] = new SelectList(_context.Editora, "IdEditora", "Nome", livro.Editora);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLivro,Codigo,Nome,Autor,Editora")] Livro livro)
        {
            if (id != livro.IdLivro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if ((_context.Livro.Where(x => x.Codigo == livro.Codigo && livro.IdLivro != x.IdLivro).Count() > 0) ||
                    (_context.Livro.Where(x => x.Nome == livro.Nome && livro.IdLivro != x.IdLivro).Count() > 0))
                {
                    ViewBag.Message = "*Já existe um livro cadastrado com esses dados";
                }
                else {
                    try
                    {
                        _context.Update(livro);
                        await _context.SaveChangesAsync();


                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LivroExists(livro.IdLivro))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }

            }
            ViewData["Autor"] = new SelectList(_context.Autor, "IdAutor", "Nome", livro.Autor);
            ViewData["Editora"] = new SelectList(_context.Editora, "IdEditora", "Nome", livro.Editora);
            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.IdLivro == id);
        }
    }
}
