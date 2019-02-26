using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public Cart(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }
    }
}