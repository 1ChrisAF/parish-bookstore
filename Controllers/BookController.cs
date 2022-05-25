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
    public class BookController : Controller
    {
        private readonly BookstoreContext _context;

        public BookController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
              return _context.Books != null ? 
                          View(await _context.Books.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Books'  is null.");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
