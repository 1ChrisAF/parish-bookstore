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

    public DbSet<TestUser> Users {get; set;}

    public DbSet<TempModel> Temp {get; set;}

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
        modelBuilder.Entity<TempModel>().HasData(
            new TempModel {Id = 1, ImageName = ""}
        );
        
        modelBuilder.Entity<BookCategory>().HasData(
            new BookCategory {BookCategoryId = 1, CategoryName = "unassigned"},
            new BookCategory {BookCategoryId = 2, CategoryName = "Prayer & Service Books"},
            new BookCategory {BookCategoryId = 3, CategoryName = "Fathers & Patristics"},
            new BookCategory {BookCategoryId = 4, CategoryName = "Spiritual Development"},
            new BookCategory {BookCategoryId = 5, CategoryName = "Church History"},
            new BookCategory {BookCategoryId = 6, CategoryName = "Liturgics & Services"}
        );
        modelBuilder.Entity<IconCategory>().HasData(
            new IconCategory {IconCategoryId = 1, CategoryName = "unassigned"},
            new IconCategory {IconCategoryId = 2, CategoryName = "Christ"},
            new IconCategory {IconCategoryId = 3, CategoryName = "Theotokos"},
            new IconCategory {IconCategoryId = 4, CategoryName = "Angels"},
            new IconCategory {IconCategoryId = 5, CategoryName = "Saints"},
            new IconCategory {IconCategoryId = 6, CategoryName = "Feasts"}
        );
        modelBuilder.Entity<HomeAltarItemCategory>().HasData(
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 1, CategoryName = "unassigned"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 2, CategoryName = "Censers"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 3, CategoryName = "Charcoal"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 4, CategoryName = "Incense"},
            new HomeAltarItemCategory {HomeAltarItemCategoryId = 5, CategoryName = "Vigil Lamps & Supplies"}
        );
        modelBuilder.Entity<GeneralItemCategory>().HasData(
            new GeneralItemCategory {GeneralItemCategoryId = 1, CategoryName = "unassigned"},
            new GeneralItemCategory {GeneralItemCategoryId = 2, CategoryName = "Gifts"},
            new GeneralItemCategory {GeneralItemCategoryId = 3, CategoryName = "Cross Necklaces"},
            new GeneralItemCategory {GeneralItemCategoryId = 4, CategoryName = "Seasonal"}
        );
    }
    
}