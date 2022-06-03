using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace parish_bookstore.Models
{
    public class BookstoreContext : IdentityDbContext<IdentityUser>
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {

        }
    }
}