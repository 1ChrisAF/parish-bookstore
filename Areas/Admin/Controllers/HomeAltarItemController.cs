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
    public class HomeAltarItemController : Controller
    {
        private readonly BookstoreContext _context;

        public HomeAltarItemController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: HomeAltarItem
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.AltarItems != null ? 
                          View(await _context.AltarItems.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.AltarItems'  is null.");
        }

        // GET: HomeAltarItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems
                .FirstOrDefaultAsync(m => m.HomeAltarItemId == id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }

            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: HomeAltarItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeAltarItemId,CategoryId,Name,Price,Description")] HomeAltarItem homeAltarItem)
        {
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(homeAltarItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems.FindAsync(id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }
            return View(homeAltarItem);
        }

        // POST: HomeAltarItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeAltarItemId,CategoryId,Name,Price,Description")] HomeAltarItem homeAltarItem)
        {
            ViewData["Context"] = _context;
            if (id != homeAltarItem.HomeAltarItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeAltarItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeAltarItemExists(homeAltarItem.HomeAltarItemId))
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
            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems
                .FirstOrDefaultAsync(m => m.HomeAltarItemId == id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }

            return View(homeAltarItem);
        }

        // POST: HomeAltarItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.AltarItems == null)
            {
                return Problem("Entity set 'BookstoreContext.AltarItems'  is null.");
            }
            var homeAltarItem = await _context.AltarItems.FindAsync(id);
            if (homeAltarItem != null)
            {
                _context.AltarItems.Remove(homeAltarItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeAltarItemExists(int id)
        {
          return (_context.AltarItems?.Any(e => e.HomeAltarItemId == id)).GetValueOrDefault();
        }
    }
}
