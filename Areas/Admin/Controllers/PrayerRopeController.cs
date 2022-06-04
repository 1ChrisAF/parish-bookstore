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
    public class PrayerRopeController : Controller
    {
        private readonly BookstoreContext _context;

        public PrayerRopeController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: PrayerRope
        public async Task<IActionResult> Index()
        {
              return _context.PrayerRopes != null ? 
                          View(await _context.PrayerRopes.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.PrayerRopes'  is null.");
        }

        // GET: PrayerRope/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrayerRopes == null)
            {
                return NotFound();
            }

            var prayerRope = await _context.PrayerRopes
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (prayerRope == null)
            {
                return NotFound();
            }

            return View(prayerRope);
        }

        // GET: PrayerRope/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrayerRope/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,StoreItemId,CategoryId,BookieId,KnotCount,Material,Price,Quantity,Description,ImageName")] PrayerRope prayerRope)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayerRope);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayerRope);
        }

        // GET: PrayerRope/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrayerRopes == null)
            {
                return NotFound();
            }

            var prayerRope = await _context.PrayerRopes.FindAsync(id);
            if (prayerRope == null)
            {
                return NotFound();
            }
            return View(prayerRope);
        }

        // POST: PrayerRope/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,StoreItemId,CategoryId,BookieId,KnotCount,Material,Price,Quantity,Description,ImageName")] PrayerRope prayerRope)
        {
            if (id != prayerRope.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerRope);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerRopeExists(prayerRope.ItemId))
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
            return View(prayerRope);
        }

        // GET: PrayerRope/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrayerRopes == null)
            {
                return NotFound();
            }

            var prayerRope = await _context.PrayerRopes
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (prayerRope == null)
            {
                return NotFound();
            }

            return View(prayerRope);
        }

        // POST: PrayerRope/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrayerRopes == null)
            {
                return Problem("Entity set 'BookstoreContext.PrayerRopes'  is null.");
            }
            var prayerRope = await _context.PrayerRopes.FindAsync(id);
            if (prayerRope != null)
            {
                _context.PrayerRopes.Remove(prayerRope);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerRopeExists(int id)
        {
          return (_context.PrayerRopes?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
