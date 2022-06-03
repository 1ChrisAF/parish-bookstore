using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace parish_bookstore.Models
{
    public class BookstoreContext : IdentityDbContext<StoreUser>
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {

        }

        public DbSet<StoreItem> StoreItems {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<BookCategory> BookCategories {get; set;}
        public DbSet<Icon> Icons {get; set;}
        public DbSet<IconCategory> IconCategories {get; set;}
        public DbSet<PrayerRope> PrayerRopes {get; set;}
        public DbSet<PrayerRopeCategory> PrayerRopeCategories {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<ItemCategory> ItemCategories {get; set;}
        public DbSet<Bookie> Bookies {get; set;}
        public DbSet<StoreUser> Users {get; set;}
        public DbSet<CartItem> CartItems {get; set;}
    }
}