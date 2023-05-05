using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class ProductTypeController : Controller
    {
        Models.AdminContext dbType = new Models.AdminContext();
        //
        // GET: /Administrator/ProductType/
        [HandleError]
        public ActionResult Index(string error)
        {
            
                ViewBag.TypeError = error;
                return View(dbType.ProductTypes.ToList());
            
        }

        [HandleError]
        [HttpGet]
        public ActionResult Create()
        {
           
                ViewBag.cateListCreate = new SelectList(dbType.Categories, "cateID", "cateName");
                return View();
            
        }

        [HandleError]
        [HttpPost]
        public ActionResult Create(Models.ProductType createType)
        {
            
                ViewBag.cateListCreate = new SelectList(dbType.Categories, "cateID", "cateName");
                try
                {
                    if (ModelState.IsValid)
                    {
                        dbType.ProductTypes.Add(createType);
                        dbType.SaveChanges();
                        ViewBag.CreateTypeError = "Thêm loại sản phẩm thành công.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.CreateTypeError = "Không thể thêm loại sản phẩm.";
                }
                return View();
            
        }

        [HandleError]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
                ViewBag.cateListEdit = new SelectList(dbType.Categories, "cateID", "cateName");
                return View(dbType.ProductTypes.SingleOrDefault(e => e.typeID.Equals(id)));
            
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(Models.ProductType editType)
        {
           
                ViewBag.cateListEdit = new SelectList(dbType.Categories, "cateID", "cateName");
                try
                {
                    if (ModelState.IsValid)
                    {
                        dbType.Entry(editType).State = System.Data.Entity.EntityState.Modified;
                        dbType.SaveChanges();
                        ViewBag.EditTypeError = "Cập nhật loại sản phẩm thành công.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.EditTypeError = "Không thể cập nhật loại sản phẩm.";
                }
                return View();
            
        }

        [HandleError]
        public ActionResult Delete(int id)
        {
           
                var model = dbType.ProductTypes.SingleOrDefault(h => h.typeID.Equals(id));
                try
                {
                    if (model != null)
                    {
                        dbType.ProductTypes.Remove(model);
                        dbType.SaveChanges();
                        return RedirectToAction("Index", "ProductType", new { error = "Xoá loại sản phẩm thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "ProductType", new { error = "Loại sản phẩm không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "ProductType", new { error = "Không thể xoá loại sản phẩm." });
                }
            
        }
    }
}