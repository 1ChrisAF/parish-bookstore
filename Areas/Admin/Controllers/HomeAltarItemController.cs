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
    public class HomeAltarItemController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private Random rand = new Random();

        public HomeAltarItemController(BookstoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: HomeAltarItem
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.AltarItems != null ? 
                          View(await _context.AltarItems.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.AltarItems'  is null.");
        }

        // GET: HomeAltarItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems
                .FirstOrDefaultAsync(m => m.HomeAltarItemId == id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }

            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: HomeAltarItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeAltarItemId,CategoryId,Name,Price,Quantity,Description,Image")] HomeAltarItem homeAltarItem)
        {
            string trustedFileName = UploadedFile(homeAltarItem);
            homeAltarItem.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            if (ModelState.IsValid)
            {
                _context.Add(homeAltarItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = homeAltarItem.HomeAltarItemId});
            }
            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems.FindAsync(id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }
            createBookie(homeAltarItem);
            return View(homeAltarItem);
        }

        // See note in TempModel. Bookie allows for 
        // model editing w/o uploading a new image;
        // allows original image to persist if no
        // new image was uploaded. 
        private void createBookie(HomeAltarItem homeAltarItem)
        {
            TempModel temp = new TempModel();
            int bookie = rand.Next(100);
            while (bookie <= 0) 
            {
                bookie = rand.Next(100);
            }
            temp.Id = bookie;
            temp.ImageName = homeAltarItem.ImageName;
            homeAltarItem.Bookie = bookie;
            _context.Add(temp);
            _context.Update(homeAltarItem);
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Temp] ON");
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Temp] OFF");
            _context.Database.CloseConnection();
        }

        private void deleteBookie(HomeAltarItem homeAltarItem)
        {
            _context.Temp.Remove(_context.Temp.Find(homeAltarItem.Bookie));
            _context.SaveChanges();
        }

        // POST: HomeAltarItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeAltarItemId,CategoryId,Bookie,Name,Price,Quantity,Description,Image")] HomeAltarItem homeAltarItem)
        {
            ViewData["Context"] = _context;
            if (homeAltarItem.Image == null) 
            {
               homeAltarItem.ImageName = _context.Temp.Find(homeAltarItem.Bookie).ImageName;
               deleteBookie(homeAltarItem);
            }
            else
            {
                string trustedFileName = UploadedFile(homeAltarItem);
                homeAltarItem.ImageName = trustedFileName;
            }

            if (id != homeAltarItem.HomeAltarItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeAltarItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeAltarItemExists(homeAltarItem.HomeAltarItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = homeAltarItem.HomeAltarItemId});
            }
            return View(homeAltarItem);
        }

        // GET: HomeAltarItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.AltarItems == null)
            {
                return NotFound();
            }

            var homeAltarItem = await _context.AltarItems
                .FirstOrDefaultAsync(m => m.HomeAltarItemId == id);
            if (homeAltarItem == null)
            {
                return NotFound();
            }

            return View(homeAltarItem);
        }

        // POST: HomeAltarItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.AltarItems == null)
            {
                return Problem("Entity set 'BookstoreContext.AltarItems'  is null.");
            }
            var homeAltarItem = await _context.AltarItems.FindAsync(id);
            if (homeAltarItem != null)
            {
                _context.AltarItems.Remove(homeAltarItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(HomeAltarItem item)  
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

        private bool HomeAltarItemExists(int id)
        {
          return (_context.AltarItems?.Any(e => e.HomeAltarItemId == id)).GetValueOrDefault();
        }
    }
}
