using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Order
    {

        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        [Phone]
        public string CustomerPhone { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 12)]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string CustomerAddress { get; set; }
    }
}