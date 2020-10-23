using BookShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BookShopAPI.Data
{
    /// <summary>
    /// <see cref="BookShopContext"/> is a database management object
    /// </summary>
    public class BookShopContext : DbContext
    {
        public BookShopContext([NotNull] DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Data context configuring
        /// </summary>
        /// <param name="optionsBuilder">Database options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = BookShop.db;");
        }

        /// <summary>
        /// Setting at model creating time
        /// </summary>
        /// <param name="modelBuilder">Pre build model settings</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add default data to a new database
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Author = "John Tolkien", Title = "The Lord of the Rings", Publication = new DateTime(1954, 7, 29), AgeCategory = AgeCategory.Fifteen, Cover = Cover.SoftCover, Genre = Genre.Novel },
                new Book() { Id = 2, Author = "Stephen William Hawking", Title = "A Brief History of Time", Publication = new DateTime(1988, 5, 20), AgeCategory = AgeCategory.Eighteen, Cover = Cover.HardCover, Genre = Genre.Sciense },
                new Book() { Id = 3, Author = "Jules Verne", Title = "Twenty Thousand Leagues Under the Sea", Publication = new DateTime(1870, 1, 5), AgeCategory = AgeCategory.Ten, Cover = Cover.SoftCover, Genre = Genre.Novel },
                new Book() { Id = 4, Author = "Antoine de Saint-Exupery", Title = "The Little Prince", Publication = new DateTime(1943, 4, 6), AgeCategory = AgeCategory.Three, Cover = Cover.SoftCover, Genre = Genre.Sciense });
        }
    }
}