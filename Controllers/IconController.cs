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

        public IconController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: Icon
        public async Task<IActionResult> Index()
        {
              return _context.Icons != null ? 
                          View(await _context.Icons.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Icons'  is null.");
        }

        // GET: Icon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
