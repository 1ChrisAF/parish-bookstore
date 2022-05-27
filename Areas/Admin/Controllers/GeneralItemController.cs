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
    public class GeneralItemController : Controller
    {
        private readonly BookstoreContext _context;

        public GeneralItemController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: GeneralItem
        public async Task<IActionResult> Index()
        {
              return _context.GeneralItems != null ? 
                          View(await _context.GeneralItems.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.GeneralItems'  is null.");
        }

        // GET: GeneralItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralItems == null)
            {
                return NotFound();
            }

            var generalItem = await _context.GeneralItems
                .FirstOrDefaultAsync(m => m.GeneralItemId == id);
            if (generalItem == null)
            {
                return NotFound();
            }

            return View(generalItem);
        }

        // GET: GeneralItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneralItemId,CategoryId,Name,Price,Description")] GeneralItem generalItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalItem);
        }

        // GET: GeneralItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralItems == null)
            {
                return NotFound();
            }

            var generalItem = await _context.GeneralItems.FindAsync(id);
            if (generalItem == null)
            {
                return NotFound();
            }
            return View(generalItem);
        }

        // POST: GeneralItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneralItemId,CategoryId,Name,Price,Description")] GeneralItem generalItem)
        {
            if (id != generalItem.GeneralItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralItemExists(generalItem.GeneralItemId))
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
            return View(generalItem);
        }

        // GET: GeneralItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralItems == null)
            {
                return NotFound();
            }

            var generalItem = await _context.GeneralItems
                .FirstOrDefaultAsync(m => m.GeneralItemId == id);
            if (generalItem == null)
            {
                return NotFound();
            }

            return View(generalItem);
        }

        // POST: GeneralItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralItems == null)
            {
                return Problem("Entity set 'BookstoreContext.GeneralItems'  is null.");
            }
            var generalItem = await _context.GeneralItems.FindAsync(id);
            if (generalItem != null)
            {
                _context.GeneralItems.Remove(generalItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralItemExists(int id)
        {
          return (_context.GeneralItems?.Any(e => e.GeneralItemId == id)).GetValueOrDefault();
        }
    }
}
