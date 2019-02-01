using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        
    }
}