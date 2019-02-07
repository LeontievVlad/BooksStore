using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string NameCategory { get; set; }

        public virtual IPagedList<Book> Books { get; set; }
        
    }
}