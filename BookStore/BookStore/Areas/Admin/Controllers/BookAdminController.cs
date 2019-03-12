using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;


namespace BookStore.Areas.Admin.Controllers
{
    public class BookAdminController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(string adName, string adPassword)
        {

            if(adName == "admin" && adPassword == "admin")
            {
                Session["admin"] = adName;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
            
        }

        public ActionResult DelSession()
        {
            Session.Remove("admin");
            return RedirectToAction("Admin");
        }

        // GET: Books
        public ActionResult Index()
        {
            
            var books = db.Books.Include(b => b.Category);
            return View(books.OrderByDescending(x => x.BookId).ToList());
        }

        

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "NameCategory");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,Author,Desription,Price,ImagePath,ImageFile,RatingBook,CategoryId")] Book book)
        {
            string filename = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
            string extension = Path.GetExtension(book.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            book.ImagePath = "~/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/images/"), filename);
            book.ImageFile.SaveAs(filename);

            if(book.RatingBook != 0)
            {
            var count = db.Comments.Where(b => b.ThisBook == book.BookId).Count();
            var ratingCom = db.Comments.Where(b => b.ThisBook == book.BookId).Sum(x => x.Rating);
            var rating = ratingCom / count;
            book.RatingBook = rating;
            }
            

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "NameCategory", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "NameCategory", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Author,Desription,Price,ImagePathName,ImagePath,ImageFile,CategoryId")] Book book)
        {
            
            
            string filename = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
            string extension = Path.GetExtension(book.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            book.ImagePath = "~/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/images/"), filename);
            book.ImageFile.SaveAs(filename);
           
            

            

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "NameCategory", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
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