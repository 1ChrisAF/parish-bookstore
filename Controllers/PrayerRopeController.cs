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
    public class PrayerRopeController : Controller
    {
        private readonly BookstoreContext _context;

        BookstoreContext viewContext;

        public PrayerRopeController(BookstoreContext context)
        {
            _context = context;
            viewContext = context;
        }

        // GET: PrayerRope
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = viewContext;
              return _context.PrayerRopes != null ? 
                          View(await _context.PrayerRopes.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.PrayerRopes'  is null.");
        }

        // GET: PrayerRope/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = viewContext;
            if (id == null || _context.PrayerRopes == null)
            {
                return NotFound();
            }

            var prayerRope = await _context.PrayerRopes
                .FirstOrDefaultAsync(m => m.PrayerRopeId == id);
            if (prayerRope == null)
            {
                return NotFound();
            }

            return View(prayerRope);
        }
    }
}
