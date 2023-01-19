using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppContactos.Models;

namespace AppContactos.Controllers
{
    public class ImportantDatesController : Controller
    {
        private readonly ContactosWebContext _context;

        public ImportantDatesController(ContactosWebContext context)
        {
            _context = context;
        }

        // GET: ImportantDates
        public async Task<IActionResult> Index()
        {
            var contactosWebContext = _context.ImportantDates.Include(i => i.IdUserNavigation);
            return View(await contactosWebContext.ToListAsync());
        }

        // GET: ImportantDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImportantDates == null)
            {
                return NotFound();
            }

            var importantDate = await _context.ImportantDates
                .Include(i => i.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importantDate == null)
            {
                return NotFound();
            }

            return View(importantDate);
        }

        // GET: ImportantDates/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ImportantDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Month,Day,Description,IdUser")] ImportantDate importantDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importantDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", importantDate.IdUser);
            return View(importantDate);
        }

        // GET: ImportantDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImportantDates == null)
            {
                return NotFound();
            }

            var importantDate = await _context.ImportantDates.FindAsync(id);
            if (importantDate == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", importantDate.IdUser);
            return View(importantDate);
        }

        // POST: ImportantDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Month,Day,Description,IdUser")] ImportantDate importantDate)
        {
            if (id != importantDate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importantDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportantDateExists(importantDate.Id))
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
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", importantDate.IdUser);
            return View(importantDate);
        }

        // GET: ImportantDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImportantDates == null)
            {
                return NotFound();
            }

            var importantDate = await _context.ImportantDates
                .Include(i => i.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importantDate == null)
            {
                return NotFound();
            }

            return View(importantDate);
        }

        // POST: ImportantDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImportantDates == null)
            {
                return Problem("Entity set 'ContactosWebContext.ImportantDates'  is null.");
            }
            var importantDate = await _context.ImportantDates.FindAsync(id);
            if (importantDate != null)
            {
                _context.ImportantDates.Remove(importantDate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportantDateExists(int id)
        {
          return _context.ImportantDates.Any(e => e.Id == id);
        }
    }
}
