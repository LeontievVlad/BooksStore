using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext() : base("BookStoreAspNet")
        {

        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Comment> Comments { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}