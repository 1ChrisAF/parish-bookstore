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
    public class HomeAltarItemCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public HomeAltarItemCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: HomeAltarItemCategory
        public async Task<IActionResult> Index()
        {
              return _context.AltarItemCategories != null ? 
                          View(await _context.AltarItemCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.AltarItemCategories'  is null.");
        }

        // GET: HomeAltarItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AltarItemCategories == null)
            {
                return NotFound();
            }

            var homeAltarItemCategory = await _context.AltarItemCategories
                .FirstOrDefaultAsync(m => m.HomeAltarItemCategoryId == id);
            if (homeAltarItemCategory == null)
            {
                return NotFound();
            }

            return View(homeAltarItemCategory);
        }
    }
}
