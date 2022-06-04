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
    public class StoreItemController : Controller
    {
        private readonly BookstoreContext _context;

        public StoreItemController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: StoreItem
        public async Task<IActionResult> Index()
        {
              return _context.StoreItems != null ? 
                          View(await _context.StoreItems.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.StoreItems'  is null.");
        }

        // GET: StoreItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StoreItems == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems
                .FirstOrDefaultAsync(m => m.StoreItemId == id);
            if (storeItem == null)
            {
                return NotFound();
            }

            return View(storeItem);
        }

        // GET: StoreItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreItemId,ItemName")] StoreItem storeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeItem);
        }

        // GET: StoreItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoreItems == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return NotFound();
            }
            return View(storeItem);
        }

        // POST: StoreItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreItemId,ItemName")] StoreItem storeItem)
        {
            if (id != storeItem.StoreItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreItemExists(storeItem.StoreItemId))
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
            return View(storeItem);
        }

        // GET: StoreItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoreItems == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems
                .FirstOrDefaultAsync(m => m.StoreItemId == id);
            if (storeItem == null)
            {
                return NotFound();
            }

            return View(storeItem);
        }

        // POST: StoreItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoreItems == null)
            {
                return Problem("Entity set 'BookstoreContext.StoreItems'  is null.");
            }
            var storeItem = await _context.StoreItems.FindAsync(id);
            if (storeItem != null)
            {
                _context.StoreItems.Remove(storeItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreItemExists(int id)
        {
          return (_context.StoreItems?.Any(e => e.StoreItemId == id)).GetValueOrDefault();
        }
    }
}
