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
    public class IconController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IconController(BookstoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Icon
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.Icons != null ? 
                          View(await _context.Icons.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Icons'  is null.");
        }

        // GET: Icon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
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

        // GET: Icon/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: Icon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IconId,CategoryId,Name,Price,Description,Image")] Icon icon)
        {
            string trustedFileName = UploadedFile(icon);
            icon.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(icon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = icon.IconId});
            }
            return View(icon);
        }

        // GET: Icon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.Icons == null)
            {
                return NotFound();
            }

            var icon = await _context.Icons.FindAsync(id);
            if (icon == null)
            {
                return NotFound();
            }
            return View(icon);
        }

        // POST: Icon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IconId,CategoryId,Name,Price,Description,Image")] Icon icon)
        {
            string trustedFileName = UploadedFile(icon);
            icon.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            if (id != icon.IconId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IconExists(icon.IconId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = icon.IconId});
            }
            return View(icon);
        }

        // GET: Icon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
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

        // POST: Icon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.Icons == null)
            {
                return Problem("Entity set 'BookstoreContext.Icons'  is null.");
            }
            var icon = await _context.Icons.FindAsync(id);
            if (icon != null)
            {
                _context.Icons.Remove(icon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(Icon icon)  
        {  
            string uniqueFileName = null;  

            if (icon.Image != null)  
            {  
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, @"media\images");  
                string fileName = icon.Image.FileName;
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
                    icon.Image.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }

        private bool IconExists(int id)
        {
          return (_context.Icons?.Any(e => e.IconId == id)).GetValueOrDefault();
        }
    }
}