using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreContext :DbContext
    {
        public BookStoreContext() :base("BookStoreContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        //public class BookStoreDb : DropCreateDatabaseIfModelChanges<BookStoreContext>
        //{
        //    protected override void Seed(BookStoreContext context)
        //    {
        //        base.Seed(context);
        //    }
        //}

        
    }
}