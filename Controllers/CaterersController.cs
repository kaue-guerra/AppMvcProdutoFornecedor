using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMvcProdutoFornecedor.Data;
using AppMvcProdutoFornecedor.Models;

namespace AppMvcProdutoFornecedor.Controllers
{
    public class CaterersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaterersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caterers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Caterers.ToListAsync());
        }

        // GET: Caterers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Caterers == null)
            {
                return NotFound();
            }

            var caterer = await _context.Caterers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caterer == null)
            {
                return NotFound();
            }

            return View(caterer);
        }

        // GET: Caterers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caterers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Caterer caterer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caterer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caterer);
        }

        // GET: Caterers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Caterers == null)
            {
                return NotFound();
            }

            var caterer = await _context.Caterers.FindAsync(id);
            if (caterer == null)
            {
                return NotFound();
            }
            return View(caterer);
        }

        // POST: Caterers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Caterer caterer)
        {
            if (id != caterer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caterer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatererExists(caterer.Id))
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
            return View(caterer);
        }

        // GET: Caterers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Caterers == null)
            {
                return NotFound();
            }

            var caterer = await _context.Caterers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caterer == null)
            {
                return NotFound();
            }

            return View(caterer);
        }

        // POST: Caterers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Caterers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Caterers'  is null.");
            }
            var caterer = await _context.Caterers.FindAsync(id);
            if (caterer != null)
            {
                _context.Caterers.Remove(caterer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatererExists(Guid id)
        {
          return _context.Caterers.Any(e => e.Id == id);
        }
    }
}
