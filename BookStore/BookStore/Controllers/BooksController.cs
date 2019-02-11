using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using BookStore.Models;
using PagedList;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books
        
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Category);
            //ViewBag.catname = new SelectList(db.Categories, "CategoryId", "NameCategory");
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult View(string search, int? page)
        {
            //dropdownlist for categories
            //SelectList categ = new SelectList(db.Categories, "NameCategory", "NameCategory");
            //ViewBag.Books = categ;
            //var books = db.Books.Include(b => b.Category);
            //ViewBag.catname = new SelectList(db.Categories, "CategoryId", "NameCategory");
            ViewBag.catname = new SelectList(db.Categories, "CategoryId", "NameCategory");
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var books = db.Books.Include(b => b.Category).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);

            
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

            



            //return View(books.ToList().ToPagedList(pageNumber, pageSize));
            //return View(books.ToList());
            //return View(books);
        }

        [HttpPost]
        public ActionResult View(int catname, int? page)
        {
            ViewBag.catname = new SelectList(db.Categories, "CategoryId", "NameCategory");

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var books = db.Books.Include(b => b.Category).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
            
            //var books = db.Books.Include(b => b.Category).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);

            if (catname != 15)
            {

                books = db.Books.Include(b => b.Category).Where(x => x.CategoryId == catname).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
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
        public ActionResult Create([Bind(Include = "Id,Title,Author,Description,Price,ImagePath,ImageFile,CategoryId")] Book book)
        {
            //if (book.ImagePath == null)
            //{
            //    book.ImagePath = "~/images/photo-1463320726281-696a485928c7.jpg";
            //}

           


                string filename = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string extension = Path.GetExtension(book.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                book.ImagePath = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                book.ImageFile.SaveAs(filename);
            
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
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Description,Price,ImagePath,ImageFile,CategoryId")] Book book)
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
            /////
            /////delete image from folder images
            System.IO.File.Delete(Server.MapPath(book.ImagePath));
            /////
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
