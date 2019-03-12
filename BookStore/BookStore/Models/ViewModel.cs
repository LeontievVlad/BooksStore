using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ViewModel
    {
        //public Book Book { get; set; }
        //public Comment Comment { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}