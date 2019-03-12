using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        private string strCom = "Com";

        
    
    // Get: View
    [HttpGet]
        public ActionResult View(string search, int? page)
        {
            
            
            ViewBag.catname = new SelectList(db.Categories.OrderBy(x => x.NameCategory), "CategoryId", "NameCategory");
            ViewBag.authorname = new SelectList(db.Books.OrderBy(x => x.Author), "BookId", "Author");
            ViewBag.ratBook = new SelectList(db.Books, "BookId", "RatingBook");
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var books = db.Books.Include(b => b.Category).OrderBy(x => x.Title).ToPagedList(pageNumber, pageSize);

            
      
            if (search == "" || search == null)
            {

                return View(books);
            }
            else
            {
                books = db.Books.Where(x => x.Title.Contains(search))
                    .OrderBy(x => x.Title).ToPagedList(pageNumber, pageSize);

                return View(books);
            }





            
        }

        [HttpPost]
        public ActionResult View(int? catname, int? page, int? authorname, string BookRating, int? byRating)
        {
            ViewBag.catname = new SelectList(db.Categories, "CategoryId", "NameCategory");
            ViewBag.authorname = new SelectList(db.Books, "BookId", "Author");
            

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var books = db.Books.Include(b => b.Category).OrderBy(x => x.BookId).ToPagedList(pageNumber, pageSize);

            if(byRating > 0 && byRating < 11)
            {
                books = db.Books.Where(b => b.RatingBook == byRating).OrderBy(x => x.Title).ToPagedList(pageNumber, pageSize);
                return View(books);
            }else
            if(byRating == 11)
            {
                return RedirectToAction("View", "Books");
            }
            else
            if (BookRating == "Popular")
            {
                books = db.Books.OrderByDescending(x => x.RatingBook).ToPagedList(pageNumber, pageSize);
                return View(books);
            }else
            
            if (authorname > 0)
            {

                books = db.Books.Where(x => x.BookId == authorname).OrderBy(x => x.BookId).ToPagedList(pageNumber, pageSize);
                return View(books);

            }else
            if (catname > 1)
            {

                books = db.Books.Include(b => b.Category).Where(x => x.CategoryId == catname).OrderBy(x => x.BookId).ToPagedList(pageNumber, pageSize);
                return View(books);

            }

            else
            {
                return RedirectToAction("View", "Books");
            }
        }



        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            
            var count = db.Comments.Where(b => b.ThisBook == id).Count();
            var ratingCom = db.Comments.Where(b => b.ThisBook == id).Sum(x => x.Rating);
            var rating = ratingCom / count;
            

            book.RatingBook = rating;
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            
            
            

            if (book == null)
            {
                return HttpNotFound();
            }

            
            
            book.Comments = db.Comments
            .Where(x => x.ThisBook == book.BookId)
            .OrderByDescending(o => o.CommentId)
            .ToList();
            
            return View(book);
        }

        

        [HttpPost]
        public ActionResult Details(Comment com, int Bookid, string BCom, int Rating, string Name)
        {
            
            com.Rating = Rating;
            com.StrComment = BCom;
            com.ThisBook = Bookid;
            com.Name = Name;
            
            db.Comments.Add(com);
            db.SaveChanges();
            

            

            var comment = db.Comments
                .Where(c => c.ThisBook == Bookid)
                .OrderByDescending(o => o.CommentId)
                .ToList();
            return View(comment);
        }


        [HttpPost]
        public ActionResult AddComment([Bind(Include = "CommentId,Rating,StrComment,Name,ThisBook") ]Comment com, int Bookid, int Rating, string BCom, string Name)
        {
            //1. Add to db
            com.Rating = Rating;
            com.StrComment = BCom;
            com.ThisBook = Bookid;
            com.Name = Name;
            db.Comments.Add(com);
            db.SaveChanges();


           

            return RedirectToAction("Details", new { id = Bookid });
            
        }

        
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
