using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CommentList
    {     
            public Comment Comment { get; set; }
            

            public CommentList(Comment comment)
            {
                Comment = comment;
                
            }
        

    }
}