using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Comment
    {
        

        public int CommentId { get; set; }
        public int Rating { get; set; }
        public string StrComment { get; set; }
        public string Name { get; set; }
        public int ThisBook { get; set; }
        
    }
}