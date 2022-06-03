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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Added because decorators in models weren't satisfying the type warns
            // ***
            var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
            // ***

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StoreItem>().HasData(
                new StoreItem {StoreItemId = 1, ItemName = "Book"},
                new StoreItem {StoreItemId = 2, ItemName = "Icon"},
                new StoreItem {StoreItemId = 3, ItemName = "PrayerRope"},
                new StoreItem {StoreItemId = 4, ItemName = "Item"}
            );
            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory {CategoryId = 1, CategoryName = "unassigned"},
                new BookCategory {CategoryId = 2, CategoryName = "Prayer & Service Books"},
                new BookCategory {CategoryId = 3, CategoryName = "Patristics"}
            );
            modelBuilder.Entity<IconCategory>().HasData(
                new IconCategory {CategoryId = 1, CategoryName = "unassigned"},
                new IconCategory {CategoryId = 2, CategoryName = "Christ"},
                new IconCategory {CategoryId = 3, CategoryName = "Theotokos"},
                new IconCategory {CategoryId = 4, CategoryName = "Angel"},
                new IconCategory {CategoryId = 5, CategoryName = "Saint"},
                new IconCategory {CategoryId = 6, CategoryName = "Feast"}
            );
            modelBuilder.Entity<PrayerRopeCategory>().HasData(
                new PrayerRopeCategory {CategoryId = 1, CategoryName = "unassigned"},
                new PrayerRopeCategory {CategoryId = 2, CategoryName = "Knotted"},
                new PrayerRopeCategory {CategoryId = 3, CategoryName = "Beaded"}
            );
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory {CategoryId = 1, CategoryName = "unassigned"},
                new ItemCategory {CategoryId = 2, CategoryName = "Seasonal"},
                new ItemCategory {CategoryId = 3, CategoryName = "Gifts"},
                new ItemCategory {CategoryId = 4, CategoryName = "Jewelry"}
            );
        }
    }
}