using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parish_bookstore.Models;

namespace parish_bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IconCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public IconCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: Admin/IconCategory
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.IconCategories != null ? 
                          View(await _context.IconCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.IconCategories'  is null.");
        }

        // GET: Admin/IconCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.IconCategories == null)
            {
                return NotFound();
            }

            var iconCategory = await _context.IconCategories
                .FirstOrDefaultAsync(m => m.IconCategoryId == id);
            if (iconCategory == null)
            {
                return NotFound();
            }

            return View(iconCategory);
        }

        // GET: Admin/IconCategory/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: Admin/IconCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IconCategoryId,CategoryName")] IconCategory iconCategory)
        {
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(iconCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iconCategory);
        }

        // GET: Admin/IconCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.IconCategories == null)
            {
                return NotFound();
            }

            var iconCategory = await _context.IconCategories.FindAsync(id);
            if (iconCategory == null)
            {
                return NotFound();
            }
            return View(iconCategory);
        }

        // POST: Admin/IconCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IconCategoryId,CategoryName")] IconCategory iconCategory)
        {
            ViewData["Context"] = _context;
            if (id != iconCategory.IconCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iconCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IconCategoryExists(iconCategory.IconCategoryId))
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
            return View(iconCategory);
        }

        // GET: Admin/IconCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.IconCategories == null)
            {
                return NotFound();
            }

            var iconCategory = await _context.IconCategories
                .FirstOrDefaultAsync(m => m.IconCategoryId == id);
            if (iconCategory == null)
            {
                return NotFound();
            }

            return View(iconCategory);
        }

        // POST: Admin/IconCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.IconCategories == null)
            {
                return Problem("Entity set 'BookstoreContext.IconCategories'  is null.");
            }
            var iconCategory = await _context.IconCategories.FindAsync(id);
            if (iconCategory != null)
            {
                _context.IconCategories.Remove(iconCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IconCategoryExists(int id)
        {
          return (_context.IconCategories?.Any(e => e.IconCategoryId == id)).GetValueOrDefault();
        }
    }
}
