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
    }
}
