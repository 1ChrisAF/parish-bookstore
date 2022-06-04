using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parish_bookstore.Models;

namespace parish_bookstore.Areas_Admin_Controllers
{
    public class PrayerRopeCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public PrayerRopeCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: PrayerRopeCategory
        public async Task<IActionResult> Index()
        {
              return _context.PrayerRopeCategories != null ? 
                          View(await _context.PrayerRopeCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.PrayerRopeCategories'  is null.");
        }

        // GET: PrayerRopeCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrayerRopeCategories == null)
            {
                return NotFound();
            }

            var prayerRopeCategory = await _context.PrayerRopeCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (prayerRopeCategory == null)
            {
                return NotFound();
            }

            return View(prayerRopeCategory);
        }

        // GET: PrayerRopeCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrayerRopeCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] PrayerRopeCategory prayerRopeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayerRopeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayerRopeCategory);
        }

        // GET: PrayerRopeCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrayerRopeCategories == null)
            {
                return NotFound();
            }

            var prayerRopeCategory = await _context.PrayerRopeCategories.FindAsync(id);
            if (prayerRopeCategory == null)
            {
                return NotFound();
            }
            return View(prayerRopeCategory);
        }

        // POST: PrayerRopeCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] PrayerRopeCategory prayerRopeCategory)
        {
            if (id != prayerRopeCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerRopeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerRopeCategoryExists(prayerRopeCategory.CategoryId))
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
            return View(prayerRopeCategory);
        }

        // GET: PrayerRopeCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrayerRopeCategories == null)
            {
                return NotFound();
            }

            var prayerRopeCategory = await _context.PrayerRopeCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (prayerRopeCategory == null)
            {
                return NotFound();
            }

            return View(prayerRopeCategory);
        }

        // POST: PrayerRopeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrayerRopeCategories == null)
            {
                return Problem("Entity set 'BookstoreContext.PrayerRopeCategories'  is null.");
            }
            var prayerRopeCategory = await _context.PrayerRopeCategories.FindAsync(id);
            if (prayerRopeCategory != null)
            {
                _context.PrayerRopeCategories.Remove(prayerRopeCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerRopeCategoryExists(int id)
        {
          return (_context.PrayerRopeCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
