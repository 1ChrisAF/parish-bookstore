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
    public class BookCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public BookCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: BookCategory
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.BookCategories != null ? 
                          View(await _context.BookCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.BookCategories'  is null.");
        }

        // GET: BookCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategory/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: BookCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCategoryId,CategoryName")] BookCategory bookCategory)
        {
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        // GET: BookCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCategoryId,CategoryName")] BookCategory bookCategory)
        {
            ViewData["Context"] = _context;
            if (id != bookCategory.BookCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.BookCategoryId))
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
            return View(bookCategory);
        }

        // GET: BookCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.BookCategories == null)
            {
                return Problem("Entity set 'BookstoreContext.BookCategories'  is null.");
            }
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
          return (_context.BookCategories?.Any(e => e.BookCategoryId == id)).GetValueOrDefault();
        }
    }
}
