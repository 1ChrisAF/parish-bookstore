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
    public class BookController : Controller
    {
        private readonly BookstoreContext _context;


        public BookController(BookstoreContext context)
        {
            _context = context;
        }

        

        // GET: Book
        public async Task<IActionResult> Index()
        {
            ViewData["Context"] = _context;
            // Return all items EXCEPT those w/ the category "unassigned"
              return _context.Books != null ? 
                          View(await _context.Books.Where(b => b.BookCategoryId != 1).ToListAsync()) :
                          Problem("Entity set 'BookstoreContext.Books'  is null.");
        }

        public async Task<IActionResult> FilteredIndex(int? id)
        {
            ViewData["Context"] = _context;
            ViewData["CurrentCategory"] = id;
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookstoreContext.Books'  is null.");
            }
            var filteredBooks = await _context.Books.Where(b => b.BookCategoryId == id).ToListAsync();
            return  View(filteredBooks);
                          
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
        [Route("/Book/AddToCart", Name="addtocart")]
        public RedirectToActionResult AddItemToCart(int userId, int itemId, int quantity)
        {	
            // Find item in context
            var item = _context.Books.Find(itemId);
            // Find user in context
            var user = _context.Users.Find(userId);
            // Find user cart in context
            var cart = _context.Carts.Find(user.CartId);
            // If user DOES already have the item in cart...
            if (productExistsInCart(item, userId))
            {
                var cartItem = (CartItem)_context.CartItems.Where(c => c.CartId == user.CartId && c.Item == item);
                cartItem.Quantity += 1;
                _context.Update(cartItem);
            }
            else
            {
                // ELSE, create item/quantity.
                // Item and Quantity MUST have the same index.
                CartItem cartItem = new CartItem();
                cartItem.CartId = user.CartId;
                cartItem.Item = item;
                cartItem.Quantity = quantity;
                _context.CartItems.Add(cartItem);
            }
            _context.Update(user);
            
            _context.SaveChanges();
            return RedirectToAction("Details", new {id = itemId});
        }

        private bool productExistsInCart(Book book, int userId)
        {
            bool isInCart = false;
            var user = _context.Users.Find(userId);
            // Retrieve user CartId
            int userCart = user.CartId;
            // Pull all cart items associated w/ user cart id
            var cartItems = _context.CartItems.Where(ci => ci.CartId == userCart).ToList();
            // Try to find book type in items associated w/ user cart id,
            // shoudl return NULL if not found
            var cartItemType = cartItems.Find(ci => ci.Item == book);
            if (cartItemType != null)
            { 
                // If NOT NULL, item is in user cart,
                // does not need to be created, quant
                // just needs to be updated.
                isInCart = true;
            }
            return isInCart;
        }
    }
}
