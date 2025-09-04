using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    public class LibraryDbContext : DbContext
    {
        private readonly string connectionString;
        public LibraryDbContext()
        {
            connectionString = "Data Source=ACERNITRO5\\SQLEXPRESS03;Initial Catalog=LibraryDB;Integrated Security=True;Trust Server Certificate=True";
        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<BookAuthorModel> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình mối quan hệ nhiều-nhiều giữa Book và Author
            modelBuilder.Entity<BookAuthorModel>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthorModel>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthorModel>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            // Cấu hình mối quan hệ 1-nhiều giữa Publisher và Book
            modelBuilder.Entity<BookModel>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            // Cấu hình mối quan hệ 1-nhiều giữa Reader và Loan
            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.Reader)
                .WithMany(r => r.Loans)
                .HasForeignKey(l => l.ReaderId);

            // Cấu hình mối quan hệ 1-nhiều giữa Book và Loan
            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
