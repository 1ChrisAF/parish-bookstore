using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.EntityFrameworkCore;
using parish_bookstore.Models;

namespace parish_bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        private Random rand = new Random();

        public BookController(BookstoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        

        // GET: Book
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
              return _context.Books != null ? 
                          View(await _context.Books.ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Books'  is null.");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["Context"] = _context;
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookCategoryId,Title,Author,PageCount,Publisher,PublishYear,ISBN,Price,Quantity,Description,Image")] Book book)
        {
            string trustedFileName = UploadedFile(book);
            book.ImageName = trustedFileName;
            ViewData["Context"] = _context;
            
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = book.BookId });
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            try
            {
                createBookie(book);
            }
            catch (Exception)
            {
                return RedirectToAction("EditError", new { id = book.BookId });
            }
            
            return View(book);
        }

        // See note in TempModel. Bookie allows for 
        // model editing w/o uploading a new image;
        // allows original image to persist if no
        // new image was uploaded. 
        private void createBookie(Book book)
        {
            TempModel temp = new TempModel();
            int bookie = rand.Next(100);
            while (bookie <= 0) 
            {
                bookie = rand.Next(100);
            }
            temp.Id = bookie;
            temp.ImageName = book.ImageName;
            book.Bookie = bookie;
            _context.Add(temp);
            _context.Update(book);
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Temp] ON");
            _context.SaveChanges();
            _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Temp] OFF");
            _context.Database.CloseConnection();
        }

        private void deleteBookie(Book book)
        {
            _context.Temp.Remove(_context.Temp.Find(book.Bookie));
            _context.SaveChanges();
        }
        
        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookCategoryId,Bookie,Title,Author,PageCount,Publisher,PublishYear,ISBN,Price,Quantity,Description,Image")] Book book)
        {
            ViewData["Context"] = _context;
            if (book.Image == null) 
            {
               book.ImageName = _context.Temp.Find(book.Bookie).ImageName;
               try
            {
                deleteBookie(book);
            }
            catch (Exception)
            {
                return RedirectToAction("EditError", new { id = book.BookId });
            }
               
            }
            else
            {
                string trustedFileName = UploadedFile(book);
                book.ImageName = trustedFileName;
            }
            
            if (id != book.BookId)
            {
                return NotFound();
            }
            
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = book.BookId });
            }
            return View(book);
        }

        public async Task<IActionResult> EditError(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Context"] = _context;
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Context"] = _context;
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookstoreContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(Book book)  
        {  
            string uniqueFileName = null;  

            if (book.Image != null)  
            {  
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, @"media\images");  
                string fileName = book.Image.FileName;
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
                    book.Image.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
