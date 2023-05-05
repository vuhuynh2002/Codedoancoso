using PagedList;
using ShopProject.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShopProject.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        Models.AdminContext db = new Models.AdminContext();
        Repository.ShopDAO dao = new Repository.ShopDAO();
        [HandleError]
        public ActionResult Index(int ?page)
        {
            
               
            if (page == null) page = 1;
            var sp = db.Products.OrderBy(x => x.proID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            var dt = db.Products.Find(id);
            return View(dt);
        }

        public ActionResult Create()
        {
            //Để tạo dropdownList bên view
            var hangselected = new SelectList(db.Producers, "pdcID", "TpdcName");
            ViewBag.Mahang = hangselected;
            var tyoeselected = new SelectList(db.ProductTypes, "pdcID", "typeName");
            ViewBag.Mahang = hangselected;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.Products.Add(product);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}