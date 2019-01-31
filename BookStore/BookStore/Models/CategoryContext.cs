using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }

    public class CategoryDbInit : DropCreateDatabaseAlways<CategoryContext>
    {
        protected override void Seed(CategoryContext context)
        {
            base.Seed(context);
        }
    }
}