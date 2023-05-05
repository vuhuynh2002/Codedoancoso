using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopProject.Areas.Shopper.Models;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Shopper/Home
        Models.UserContext db = new Models.UserContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(Customer customer)
        {
            try
            {
                // Thêm người dùng  mới
                db.Customers.Add(customer);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Login");
                }
                return View("Register");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.Customers.SingleOrDefault(x => x.cusEmail.Equals(userMail) && x.cusPassword.Equals(password));


            if (islogin != null)
            {
                if (userMail == "vuhuynh@gmail.com")
                {
                    Session["use"] = islogin;
                    Session["email"] = userMail;

                    // return RedirectToActionPermanent("Index", "Administrator/Home");
                    return RedirectToAction("Index", "Home", new { area = "Administrator"});
                    
                }
                else
                {
                    Session["use"] = islogin;
                    string username = islogin.cusFullName;
                    Session["email"] = userMail;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
              
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {

            Session["use"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {

            string email = (string)Session["email"];
            ViewBag.Email = email; // Đưa email vào ViewBag
            return View();

            
        }

       
    }
}