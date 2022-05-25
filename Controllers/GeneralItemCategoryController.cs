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
    public class GeneralItemCategoryController : Controller
    {
        private readonly BookstoreContext _context;

        public GeneralItemCategoryController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: GeneralItemCategory
        public async Task<IActionResult> Index()
        {
              return _context.GeneralItemCategories != null ? 
                          View(await _context.GeneralItemCategories.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.GeneralItemCategories'  is null.");
        }

        // GET: GeneralItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralItemCategories == null)
            {
                return NotFound();
            }

            var generalItemCategory = await _context.GeneralItemCategories
                .FirstOrDefaultAsync(m => m.GeneralItemCategoryId == id);
            if (generalItemCategory == null)
            {
                return NotFound();
            }

            return View(generalItemCategory);
        }
    }
}
