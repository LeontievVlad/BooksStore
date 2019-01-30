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
            db.Books.Add(new Book {  Title = "Book 1",
                Author = "Author 1",
                Description = "Some Description for Book 1"
            });

           

        }

    }
}