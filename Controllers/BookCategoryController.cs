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
    public class BookCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public BookCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: BookCatgegory
        public async Task<IActionResult> Index()
        {
              return _context.BookCategories != null ? 
                          View(await _context.BookCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.BookCategories'  is null.");
        }

        // GET: BookCatgegory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
    }
}
