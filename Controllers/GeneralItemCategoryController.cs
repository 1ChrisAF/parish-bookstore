using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parish_bookstore.Models;

namespace parish_bookstore.Controllers
{
    public class GeneralItemCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public GeneralItemCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: GeneralItemCategory
        public async Task<IActionResult> Index()
        {
              return _context.GeneralItemCategories != null ? 
                          View(await _context.GeneralItemCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.GeneralItemCategories'  is null.");
        }

        // GET: GeneralItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralItemCategories == null)
            {
                return NotFound();
            }

            var generalItemCategory = await _context.GeneralItemCategories
                .FirstOrDefaultAsync(m => m.GeneralItemCategoryId == id);
            if (generalItemCategory == null)
            {
                return NotFound();
            }

            return View(generalItemCategory);
        }

        // GET: GeneralItemCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralItemCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneralItemCategoryId,CategoryName")] GeneralItemCategory generalItemCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalItemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalItemCategory);
        }

        // GET: GeneralItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralItemCategories == null)
            {
                return NotFound();
            }

            var generalItemCategory = await _context.GeneralItemCategories.FindAsync(id);
            if (generalItemCategory == null)
            {
                return NotFound();
            }
            return View(generalItemCategory);
        }

        // POST: GeneralItemCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneralItemCategoryId,CategoryName")] GeneralItemCategory generalItemCategory)
        {
            if (id != generalItemCategory.GeneralItemCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalItemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralItemCategoryExists(generalItemCategory.GeneralItemCategoryId))
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
            return View(generalItemCategory);
        }

        // GET: GeneralItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralItemCategories == null)
            {
                return NotFound();
            }

            var generalItemCategory = await _context.GeneralItemCategories
                .FirstOrDefaultAsync(m => m.GeneralItemCategoryId == id);
            if (generalItemCategory == null)
            {
                return NotFound();
            }

            return View(generalItemCategory);
        }

        // POST: GeneralItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralItemCategories == null)
            {
                return Problem("Entity set 'BookstoreContext.GeneralItemCategories'  is null.");
            }
            var generalItemCategory = await _context.GeneralItemCategories.FindAsync(id);
            if (generalItemCategory != null)
            {
                _context.GeneralItemCategories.Remove(generalItemCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralItemCategoryExists(int id)
        {
          return (_context.GeneralItemCategories?.Any(e => e.GeneralItemCategoryId == id)).GetValueOrDefault();
        }
    }
}
