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
    public class GeneralItemController : Controller
    {
        private readonly BookstoreContext _context;

        BookstoreContext viewContext;

        public GeneralItemController(BookstoreContext context)
        {
            _context = context;
            viewContext = context;
        }

        // GET: GeneralItem
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = viewContext;
              return _context.GeneralItems != null ? 
                          View(await _context.GeneralItems.Where(g => g.CategoryId != 1).ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.GeneralItems'  is null.");
        }
        
        public async Task<IActionResult> FilteredIndex(int? id)
        {
            ViewData["Context"] = _context;
            ViewData["CurrentCategory"] = id;
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookstoreContext.Books'  is null.");
            }
            var filteredItems = await _context.GeneralItems.Where(g => g.CategoryId == id).ToListAsync();
            return  View(filteredItems);
                          
        }

        // GET: GeneralItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = viewContext;
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
    }
}
