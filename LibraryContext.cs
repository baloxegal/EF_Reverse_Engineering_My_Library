using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookOrder> BookOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.HasKey(e => new { e.AuthorsId, e.BooksId });

                entity.HasIndex(e => e.BooksId, "IX_AuthorsBooks_BooksId");

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.AuthorsId);

                entity.HasOne(d => d.Books)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.BooksId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Cover)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<BookOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrdersId, e.PurchasesId });

                entity.ToTable("BookOrder");

                entity.HasIndex(e => e.PurchasesId, "IX_BookOrder_PurchasesId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.BookOrders)
                    .HasForeignKey(d => d.OrdersId);

                entity.HasOne(d => d.Purchases)
                    .WithMany(p => p.BookOrders)
                    .HasForeignKey(d => d.PurchasesId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Card).HasMaxLength(20);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
