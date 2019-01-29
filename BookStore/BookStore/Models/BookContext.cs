using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books{ get; set; }
    }

    public class BookDbInit : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Id = 1, Title = "Book 1", Description = "Some Description for Book 1" });
            db.Books.Add(new Book { Id = 2, Title = "Book 2", Description = "Some Description for Book 2" });
            db.Books.Add(new Book { Id = 3, Title = "Book 3", Description = "Some Description for Book 3" });
        }

    }
}