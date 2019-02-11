using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        
        public decimal SumCart { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}