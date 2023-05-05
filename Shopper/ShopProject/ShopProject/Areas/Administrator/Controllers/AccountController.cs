using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class AccountController : Controller
    {
        Models.AdminContext dbLog = new Models.AdminContext();
        Repository.ShopDAO dao = new Repository.ShopDAO();
        // GET: Administrator/Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken()]
        public ActionResult Login(Models.Administrator adLogin)
        {
            try
            {
                var model = dbLog.Administrators.SingleOrDefault(a => a.adAcc.Equals(adLogin.adAcc));
                if (model != null)
                {
                    if (model.adPass.Equals(dao.Encrypt(adLogin.adPass)))
                    {
                        Session["accname"]= model.adAcc;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["accname"] = null;
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                    }
                }
                else
                {
                    Session["accname"] = null;
                    ViewBag.LoginError="Sai tài khoản hoặc mật khẩu.";
                }
            }
            catch (Exception)
            {
                Session["accname"] = null;
                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["accname"] = null;
            return RedirectToAction("Login", "Home", new { area ="Shopper"});
        }
    }
}