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
    public class IconCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public IconCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: IconCategory
        public async Task<IActionResult> Index()
        {
              return _context.IconCategories != null ? 
                          View(await _context.IconCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.IconCategories'  is null.");
        }

        // GET: IconCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IconCategories == null)
            {
                return NotFound();
            }

            var iconCategory = await _context.IconCategories
                .FirstOrDefaultAsync(m => m.IconCategoryId == id);
            if (iconCategory == null)
            {
                return NotFound();
            }

            return View(iconCategory);
        }
    }
}
