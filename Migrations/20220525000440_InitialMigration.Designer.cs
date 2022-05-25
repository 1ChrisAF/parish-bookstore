﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parish_bookstore.Models;

#nullable disable

namespace parish_bookstore.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20220525000440_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CategoryBookCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryBookCategoryId");

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
                            CategoryName = "Prayer & Service Books"
                        },
                        new
                        {
                            BookCategoryId = 2,
                            CategoryName = "Fathers & Patristics"
                        },
                        new
                        {
                            BookCategoryId = 3,
                            CategoryName = "Spiritual Development"
                        },
                        new
                        {
                            BookCategoryId = 4,
                            CategoryName = "Church History"
                        },
                        new
                        {
                            BookCategoryId = 5,
                            CategoryName = "Liturgics & Services"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.GeneralItem", b =>
                {
                    b.Property<int>("GeneralItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneralItemId"), 1L, 1);

                    b.Property<int>("CategoryGeneralItemCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GeneralItemId");

                    b.HasIndex("CategoryGeneralItemCategoryId");

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
                            CategoryName = "Gifts"
                        },
                        new
                        {
                            GeneralItemCategoryId = 2,
                            CategoryName = "Cross Necklaces"
                        },
                        new
                        {
                            GeneralItemCategoryId = 3,
                            CategoryName = "Seasonal"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.HomeAltarItem", b =>
                {
                    b.Property<int>("HomeAltarItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeAltarItemId"), 1L, 1);

                    b.Property<int>("CategoryHomeAltarItemCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HomeAltarItemId");

                    b.HasIndex("CategoryHomeAltarItemCategoryId");

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
                            CategoryName = "Censers"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 2,
                            CategoryName = "Charcoal"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 3,
                            CategoryName = "Incense"
                        },
                        new
                        {
                            HomeAltarItemCategoryId = 4,
                            CategoryName = "Vigil Lamps & Supplies"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.Icon", b =>
                {
                    b.Property<int>("IconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IconId"), 1L, 1);

                    b.Property<int>("CategoryIconCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IconId");

                    b.HasIndex("CategoryIconCategoryId");

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
                            CategoryName = "Christ"
                        },
                        new
                        {
                            IconCategoryId = 2,
                            CategoryName = "Theotokos"
                        },
                        new
                        {
                            IconCategoryId = 3,
                            CategoryName = "Angels"
                        },
                        new
                        {
                            IconCategoryId = 4,
                            CategoryName = "Saints"
                        },
                        new
                        {
                            IconCategoryId = 5,
                            CategoryName = "Feasts"
                        });
                });

            modelBuilder.Entity("parish_bookstore.Models.PrayerRope", b =>
                {
                    b.Property<int>("PrayerRopeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrayerRopeId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KnotCount")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PrayerRopeId");

                    b.ToTable("PrayerRopes");
                });

            modelBuilder.Entity("parish_bookstore.Models.Book", b =>
                {
                    b.HasOne("parish_bookstore.Models.BookCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryBookCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("parish_bookstore.Models.GeneralItem", b =>
                {
                    b.HasOne("parish_bookstore.Models.GeneralItemCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryGeneralItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("parish_bookstore.Models.HomeAltarItem", b =>
                {
                    b.HasOne("parish_bookstore.Models.HomeAltarItemCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryHomeAltarItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("parish_bookstore.Models.Icon", b =>
                {
                    b.HasOne("parish_bookstore.Models.IconCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryIconCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}