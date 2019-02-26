using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text;

namespace BookStore.Controllers
{
    public class ShoppingCartController : Controller
    {

        BookStoreContext db = new BookStoreContext();
        private string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if(id == null)
            {
                return View("Bad Request");
            }
            if(Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.Books.Find(id),1)
                };
                Session[strCart] = lsCart;

            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = IsExistinCheck(id);
                if (check == -1)
                    lsCart.Add(new Cart(db.Books.Find(id), 1));
                else
                    lsCart[check].Quantity++;
                //lsCart.Add(new Cart(db.Books.Find(id), 1));
                Session[strCart] = lsCart;
            }



            return View("Index");
        }

        private int IsExistinCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for(int i = 0; i<lsCart.Count; i++)
            {
                if (lsCart[i].Book.BookId == id) return i;
            }

            return -1;
        }

        public ActionResult DeleteCart(int? id)
        {
            if(id == null)
            {
                return View("Bad Request");
            }
            int check = IsExistinCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);


            return View("Index");
        }

        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            for(int i = 0; i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lstCart;
            return View("Index");
        }

        public ActionResult CheckOut()
        {
            
            return View("CheckOut");
        }

        public ActionResult ProfBook()
        {
            //List<Cart> lstCart = (List<Cart>)Session[strCart];
            ////0. Order Name
            //// "|NB:...|" = New Book
            //// "|Q=...|" = Quantity
            //string nameoder = "";
            //foreach (Cart cart in lstCart)
            //{
            //    nameoder += cart.Book.Title + ",";
            //}
            //order.OrderName = nameoder;
            //order.OrderDate = DateTime.Now;
            //db.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfBook([Bind(Include = "OrderID,OrderName,OrderDate,CustomerName,CustomerPhone,CustomerEmail,CustomerAddress")]Order order, FormCollection frc)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            string nameoder = "";
            foreach (Cart cart in lstCart)
            {
                nameoder += cart.Book.Title + ",";
            }
            order.OrderName = nameoder;    
            //order.OrderName = "OrderName";
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                Session.Remove(strCart);


                bool result = false;
                result = SendEmail(order.CustomerEmail, "Book Store", "Your order is" + order.OrderName + " thanks!");
                //return Json(result, JsonRequestBehavior.AllowGet);

                return RedirectToAction("Sent");
            }

            return View(order);
        }



        [HttpPost]
        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            //0. Order Name
            // "|NB:...|" = New Book
            // "|Q=...|" = Quantity
            string nameoder = "";
            foreach (Cart cart in lstCart)
            {
                nameoder += "|NB:" + cart.Book.Title + "|_|Q="+ cart.Quantity + "|__";
            }


            //1. Save to Order
            Order order = new Order()
            {
                
            OrderName = nameoder,
                CustomerName = frc["cusName"],
                CustomerPhone = frc["cusPhone"],
                CustomerEmail = frc["cusEmail"],
                CustomerAddress = frc["cusAddress"],
                OrderDate = DateTime.Now

            };
            db.Orders.Add(order);
            db.SaveChanges();

            //2. Save to OrderDetail
            //foreach(Cart cart in lstCart)
            //{
            //    OrderDetail orderDetail = new OrderDetail()
            //    {
            //        OrderID = order.OrderID,
            //        BookID = cart.Book.BookId,
            //        Quantity = cart.Quantity,
            //        Price = cart.Book.Price
            //    };
            //    db.OrderDetails.Add(orderDetail);
            //    db.SaveChanges();
            //}

            //3. Remove Session
            Session.Remove(strCart);

            return View("OrderSuccess");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult SendMailToUser()
        {
            bool result = false;
            result = SendEmail("vcodesite@gmail.com", "Vcodesite Theme", "<p>Hi, Vlad, from c#</p>");
            return Json(result, JsonRequestBehavior.AllowGet);
                
        }

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {

                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                client.Send(mailMessage);





                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public ActionResult Sent()
        {
            
            return View();
        }


    }
}