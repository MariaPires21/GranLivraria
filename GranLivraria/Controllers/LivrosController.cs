using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GranLivraria.Data;
using GranLivraria.Models;

namespace GranLivraria.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros.Include(l => l.Genero).ToListAsync();
            return View(livros);
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome");
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,GeneroId,Preco,Estoque,ImagemUrl")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                // Se não foi informada uma imagem, usa a padrão
                if (string.IsNullOrEmpty(livro.ImagemUrl))
                {
                    livro.ImagemUrl = "/images/livros/capa-padrao.jpg";
                }

                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Titulo,GeneroId,Preco,Estoque,ImagemUrl")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Se não foi informada uma imagem, mantém a atual ou usa a padrão
                    if (string.IsNullOrEmpty(livro.ImagemUrl))
                    {
                        var livroExistente = await _context.Livros.AsNoTracking()
                            .FirstOrDefaultAsync(l => l.Id == id);

                        if (livroExistente != null && !string.IsNullOrEmpty(livroExistente.ImagemUrl))
                        {
                            livro.ImagemUrl = livroExistente.ImagemUrl;
                        }
                        else
                        {
                            livro.ImagemUrl = "/images/livros/capa-padrao.jpg";
                        }
                    }

                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(uint id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}