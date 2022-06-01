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
    public class HomeAltarItemCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public HomeAltarItemCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: Admin/HomeAltarItemCategory
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.AltarItemCategories != null ? 
                          View(await _context.AltarItemCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.AltarItemCategories'  is null.");
        }

        // GET: Admin/HomeAltarItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItemCategories == null)
            {
                return NotFound();
            }

            if (id == 1)
            {
                return RedirectToAction("Index");
            }

            var homeAltarItemCategory = await _context.AltarItemCategories
                .FirstOrDefaultAsync(m => m.HomeAltarItemCategoryId == id);
            if (homeAltarItemCategory == null)
            {
                return NotFound();
            }

            return View(homeAltarItemCategory);
        }

        // GET: Admin/HomeAltarItemCategory/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: Admin/HomeAltarItemCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeAltarItemCategoryId,CategoryName")] HomeAltarItemCategory homeAltarItemCategory)
        {
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(homeAltarItemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeAltarItemCategory);
        }

        // GET: Admin/HomeAltarItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItemCategories == null)
            {
                return NotFound();
            }

            if (id == 1)
            {
                return RedirectToAction("Index");
            }

            var homeAltarItemCategory = await _context.AltarItemCategories.FindAsync(id);
            if (homeAltarItemCategory == null)
            {
                return NotFound();
            }
            return View(homeAltarItemCategory);
        }

        // POST: Admin/HomeAltarItemCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeAltarItemCategoryId,CategoryName")] HomeAltarItemCategory homeAltarItemCategory)
        {
            ViewData["Context"] = _context;
            if (id != homeAltarItemCategory.HomeAltarItemCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeAltarItemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeAltarItemCategoryExists(homeAltarItemCategory.HomeAltarItemCategoryId))
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
            return View(homeAltarItemCategory);
        }

        // GET: Admin/HomeAltarItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItemCategories == null)
            {
                return NotFound();
            }

            if (id == 1)
            {
                return RedirectToAction("DeleteDisallowed", "Home");
            }

            var homeAltarItemCategory = await _context.AltarItemCategories
                .FirstOrDefaultAsync(m => m.HomeAltarItemCategoryId == id);
            if (homeAltarItemCategory == null)
            {
                return NotFound();
            }

            return View(homeAltarItemCategory);
        }

        // POST: Admin/HomeAltarItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.AltarItemCategories == null)
            {
                return Problem("Entity set 'BookstoreContext.AltarItemCategories'  is null.");
            }
            var homeAltarItemCategory = await _context.AltarItemCategories.FindAsync(id);
            if (homeAltarItemCategory != null)
            {
                foreach (HomeAltarItem item in _context.AltarItems) 
                {
                    if (item.CategoryId == id)
                    {
                        item.CategoryId = 1;
                        _context.Update(item);
                    }
                }

                _context.AltarItemCategories.Remove(homeAltarItemCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeAltarItemCategoryExists(int id)
        {
          return (_context.AltarItemCategories?.Any(e => e.HomeAltarItemCategoryId == id)).GetValueOrDefault();
        }
    }
}
