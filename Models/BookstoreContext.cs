using Microsoft.EntityFrameworkCore;

namespace parish_bookstore.Models;

public class BookstoreContext : DbContext
{
    public BookstoreContext() {}
    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Book> Books {get; set;}
    public DbSet<BookCategory> BookCategories {get; set;}
    public DbSet<Icon> Icons {get; set;}
    public DbSet<IconCategory> IconCategories {get; set;}
    public DbSet<HomeAltarItem> AltarItems {get; set;}
    public DbSet<HomeAltarItemCategory> AltarItemCategories {get; set;}
    public DbSet<PrayerRope> PrayerRopes {get; set;}
    public DbSet<GeneralItem> GeneralItems {get; set;}
    public DbSet<GeneralItemCategory> GeneralItemCategories {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BookCategory>().HasData(
            new BookCategory {BookCategoryId = 1, CategoryName = "Prayer & Service Books"},
            new BookCategory {BookCategoryId = 2, CategoryName = "Fathers & Patristics"},
            new BookCategory {BookCategoryId = 3, CategoryName = "Spiritual Development"},
            new BookCategory {BookCategoryId = 4, CategoryName = "Church History"},
            new BookCategory {BookCategoryId = 5, CategoryName = "Liturgics & Services"}
        );
        modelBuilder.Entity<IconCategory>().HasData(
            new IconCategory {IconCategoryId = 1, CategoryName = "Christ"},
            new IconCategory {IconCategoryId = 2, CategoryName = "Theotokos"},
            new IconCategory {IconCategoryId = 3, CategoryName = "Angels"},
            new IconCategory {IconCategoryId = 4, CategoryName = "Saints"},
            new IconCategory {IconCategoryId = 5, CategoryName = "Feasts"}
        );
        modelBuilder.Entity<HomeAltarItemCategory>().HasData(
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 1, CategoryName = "Censers"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 2, CategoryName = "Charcoal"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 3, CategoryName = "Incense"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 4, CategoryName = "Vigil Lamps & Supplies"}
        );
        modelBuilder.Entity<GeneralItemCategory>().HasData(
            new GeneralItemCategory {GeneralItemCategoryId = 1, CategoryName = "Gifts"},
            new GeneralItemCategory {GeneralItemCategoryId = 2, CategoryName = "Cross Necklaces"},
            new GeneralItemCategory {GeneralItemCategoryId = 3, CategoryName = "Seasonal"}
        );
    }
    
}