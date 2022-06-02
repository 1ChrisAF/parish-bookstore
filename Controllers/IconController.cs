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
    public class IconController : Controller
    {
        private readonly BookstoreContext _context;

        BookstoreContext viewContext;

        public IconController(BookstoreContext context)
        {
            _context = context;
            viewContext = context;
        }

        // GET: Icon
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = viewContext;
            // Return all items EXCEPT those w/ the category "unassigned"
              return _context.Icons != null ? 
                          View(await _context.Icons.Where(i => i.CategoryId != 1).ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Icons'  is null.");
        }

        public async Task<IActionResult> FilteredIndex(int? id)
        {
            ViewData["Context"] = _context;
            ViewData["CurrentCategory"] = id;
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookstoreContext.Books'  is null.");
            }
            var filteredIcons = await _context.Icons.Where(i => i.CategoryId == id).ToListAsync();
            return  View(filteredIcons);
                          
        }

        // GET: Icon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = viewContext;
            if (id == null || _context.Icons == null)
            {
                return NotFound();
            }

            var icon = await _context.Icons
                .FirstOrDefaultAsync(m => m.IconId == id);
            if (icon == null)
            {
                return NotFound();
            }

            return View(icon);
        }
    }
}
