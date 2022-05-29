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
    public class PrayerRopeController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PrayerRopeController(BookstoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
                .FirstOrDefaultAsync(m => m.PrayerRopeId == id);
            if (prayerRope == null)
            {
                return NotFound();
            }

            return View(prayerRope);
        }

        // GET: PrayerRope/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrayerRope/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrayerRopeId,KnotCount,Material,Price,Description,Image")] PrayerRope prayerRope)
        {
            string trustedFileName = UploadedFile(prayerRope);
            prayerRope.ImageName = trustedFileName;
            if (ModelState.IsValid)
            {
                _context.Add(prayerRope);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = prayerRope.PrayerRopeId});
            }
            return View(prayerRope);
        }

        // GET: PrayerRope/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrayerRopes == null)
            {
                return NotFound();
            }

            var prayerRope = await _context.PrayerRopes.FindAsync(id);
            if (prayerRope == null)
            {
                return NotFound();
            }
            return View(prayerRope);
        }

        // POST: PrayerRope/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrayerRopeId,KnotCount,Material,Price,Description,Image")] PrayerRope prayerRope)
        {
            string trustedFileName = UploadedFile(prayerRope);
            prayerRope.ImageName = trustedFileName;
            if (id != prayerRope.PrayerRopeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerRope);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerRopeExists(prayerRope.PrayerRopeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = prayerRope.PrayerRopeId});
            }
            return View(prayerRope);
        }

        // GET: PrayerRope/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: PrayerRope/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrayerRopes == null)
            {
                return Problem("Entity set 'BookstoreContext.PrayerRopes'  is null.");
            }
            var prayerRope = await _context.PrayerRopes.FindAsync(id);
            if (prayerRope != null)
            {
                _context.PrayerRopes.Remove(prayerRope);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(PrayerRope prayerRope)  
        {  
            string uniqueFileName = null;  

            if (prayerRope.Image != null)  
            {  
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, @"media\images");  
                string fileName = prayerRope.Image.FileName;
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
                    prayerRope.Image.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }

        private bool PrayerRopeExists(int id)
        {
          return (_context.PrayerRopes?.Any(e => e.PrayerRopeId == id)).GetValueOrDefault();
        }
    }
}
