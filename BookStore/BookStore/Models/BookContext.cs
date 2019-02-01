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

        public DbSet<Category> Categories { get; set; }
    }

    public class BookDbInit : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            base.Seed(context);
        }

     
}
}