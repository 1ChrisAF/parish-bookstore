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
    public class HomeAltarItemController : Controller
    {
        private readonly BookstoreContext _context;

        BookstoreContext viewContext;

        public HomeAltarItemController(BookstoreContext context)
        {
            _context = context;
            viewContext = context;
        }

        // GET: HomeAltarItem
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = viewContext;
              return _context.AltarItems != null ? 
                          View(await _context.AltarItems.Where(a => a.CategoryId != 1).ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.AltarItems'  is null.");
        }

        public async Task<IActionResult> FilteredIndex(int? id)
        {
            ViewData["Context"] = _context;
            ViewData["CurrentCategory"] = id;
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookstoreContext.Books'  is null.");
            }
            var filteredItems = await _context.AltarItems.Where(a => a.CategoryId == id).ToListAsync();
            return  View(filteredItems);
                          
        }

        // GET: HomeAltarItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = viewContext;
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
    }
}
