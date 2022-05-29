using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parish_bookstore.Models;

namespace parish_bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeneralItemController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GeneralItemController(BookstoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: GeneralItem
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.GeneralItems != null ? 
                          View(await _context.GeneralItems.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.GeneralItems'  is null.");
        }

        // GET: GeneralItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
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

        // GET: GeneralItem/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: GeneralItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneralItemId,CategoryId,Name,Price,Description,Image")] GeneralItem generalItem)
        {
            string trustedFileName = UploadedFile(generalItem);
            generalItem.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(generalItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = generalItem.GeneralItemId});
            }
            return View(generalItem);
        }

        // GET: GeneralItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.GeneralItems == null)
            {
                return NotFound();
            }

            var generalItem = await _context.GeneralItems.FindAsync(id);
            if (generalItem == null)
            {
                return NotFound();
            }
            return View(generalItem);
        }

        // POST: GeneralItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneralItemId,CategoryId,Name,Price,Description,Image")] GeneralItem generalItem)
        {
            string trustedFileName = UploadedFile(generalItem);
            generalItem.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            if (id != generalItem.GeneralItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralItemExists(generalItem.GeneralItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = generalItem.GeneralItemId});
            }
            return View(generalItem);
        }

        // GET: GeneralItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
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

        // POST: GeneralItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.GeneralItems == null)
            {
                return Problem("Entity set 'BookstoreContext.GeneralItems'  is null.");
            }
            var generalItem = await _context.GeneralItems.FindAsync(id);
            if (generalItem != null)
            {
                _context.GeneralItems.Remove(generalItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(GeneralItem item)  
        {  
            string uniqueFileName = null;  

            if (item.Image != null)  
            {  
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, @"media\images");  
                string fileName = item.Image.FileName;
                string fileExtension = "";
                Boolean isExtension = false;
                foreach (char c in fileName) 
                {
                    if (c == '.')
                    {
                        isExtension = true;
                    }
                    if(isExtension)
                    {
                        fileExtension += c;
                    }
                }
                uniqueFileName = Guid.NewGuid().ToString() + fileExtension;  
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))  
                {  
                    item.Image.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }

        private bool GeneralItemExists(int id)
        {
          return (_context.GeneralItems?.Any(e => e.GeneralItemId == id)).GetValueOrDefault();
        }
    }
}
