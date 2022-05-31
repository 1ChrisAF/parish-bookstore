﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parish_bookstore.Models;

#nullable disable

namespace parish_bookstore.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    partial class BookstoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("parish_bookstore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Bookie")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("parish_bookstore.Models.BookCategory", b =>
                {
                    b.Property<int>("BookCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookCategoryId");

                    b.ToTable("BookCategories");

                    b.HasData(
                        new
                        {
                            BookCategoryId = 1,
                            CategoryName = "unassigned"
                        },
                        new
                        {
                            BookCategoryId = 2,
                            CategoryName = "Prayer & Service Books"
                        },
                        new
                        {
                            BookCategoryId = 3,
                            CategoryName = "Fathers & Patristics"
                        },
                        new
                        {
                            BookCategoryId = 4,
                            CategoryName = "Spiritual Development"
                        },
                        new
                        {
                            BookCategoryId = 5,
                            CategoryName = "Church History"
                        },
                        new
                        {
                            BookCategoryId = 6,
                            CategoryName = "Liturgics & Services"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.GeneralItem", b =>
                {
                    b.Property<int>("GeneralItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneralItemId"), 1L, 1);

                    b.Property<int>("Bookie")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("GeneralItemId");

                    b.ToTable("GeneralItems");
                });

            modelBuilder.Entity("parish_bookstore.Models.GeneralItemCategory", b =>
                {
                    b.Property<int>("GeneralItemCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneralItemCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneralItemCategoryId");

                    b.ToTable("GeneralItemCategories");

                    b.HasData(
                        new
                        {
                            GeneralItemCategoryId = 1,
                            CategoryName = "unassigned"
                        },
                        new
                        {
                            GeneralItemCategoryId = 2,
                            CategoryName = "Gifts"
                        },
                        new
                        {
                            GeneralItemCategoryId = 3,
                            CategoryName = "Cross Necklaces"
                        },
                        new
                        {
                            GeneralItemCategoryId = 4,
                            CategoryName = "Seasonal"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.HomeAltarItem", b =>
                {
                    b.Property<int>("HomeAltarItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeAltarItemId"), 1L, 1);

                    b.Property<int>("Bookie")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("HomeAltarItemId");

                    b.ToTable("AltarItems");
                });

            modelBuilder.Entity("parish_bookstore.Models.HomeAltarItemCategory", b =>
                {
                    b.Property<int>("HomeAltarItemCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeAltarItemCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeAltarItemCategoryId");

                    b.ToTable("AltarItemCategories");

                    b.HasData(
                        new
                        {
                            HomeAltarItemCategoryId = 1,
                            CategoryName = "unassigned"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 2,
                            CategoryName = "Censers"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 3,
                            CategoryName = "Charcoal"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 4,
                            CategoryName = "Incense"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 5,
                            CategoryName = "Vigil Lamps & Supplies"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.Icon", b =>
                {
                    b.Property<int>("IconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IconId"), 1L, 1);

                    b.Property<int>("Bookie")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IconId");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("parish_bookstore.Models.IconCategory", b =>
                {
                    b.Property<int>("IconCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IconCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IconCategoryId");

                    b.ToTable("IconCategories");

                    b.HasData(
                        new
                        {
                            IconCategoryId = 1,
                            CategoryName = "unassigned"
                        },
                        new
                        {
                            IconCategoryId = 2,
                            CategoryName = "Christ"
                        },
                        new
                        {
                            IconCategoryId = 3,
                            CategoryName = "Theotokos"
                        },
                        new
                        {
                            IconCategoryId = 4,
                            CategoryName = "Angels"
                        },
                        new
                        {
                            IconCategoryId = 5,
                            CategoryName = "Saints"
                        },
                        new
                        {
                            IconCategoryId = 6,
                            CategoryName = "Feasts"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.PrayerRope", b =>
                {
                    b.Property<int>("PrayerRopeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrayerRopeId"), 1L, 1);

                    b.Property<int>("Bookie")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KnotCount")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PrayerRopeId");

                    b.ToTable("PrayerRopes");
                });

            modelBuilder.Entity("parish_bookstore.Models.TempModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Temp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
