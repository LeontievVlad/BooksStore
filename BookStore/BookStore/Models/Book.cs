using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Desription { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }

        public double RatingBook { get; set; }
    }
}

//public class Order
//{

//    public int OrderID { get; set; }
//    public string OrderName { get; set; }
//    public DateTime OrderDate { get; set; }
//    public string CastomerName { get; set; }
//    public string CastomerPhone { get; set; }
//    public string CastomerEmail { get; set; }
//    public string CastomerAddress { get; set; }

//}

//public class OrderDetail
//{

//    [ForeignKey("Order")]
//    public int OrderID { get; set; }

//    [ForeignKey("Book")]
//    public int BookID { get; set; }
//    public decimal Price { get; set; }
//    public int Quantity { get; set; }

//}