using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class CustomerController : Controller
    {
        Models.AdminContext dbCus = new Models.AdminContext();
        //
        // GET: /Administrator/Category/
        [HandleError]
        //Cụ thể, hàm này sẽ trả về một danh sách khách hàng hiện tại 
        // sẵn sàng cho phép tìm kiếm đối với khách hàng theo số điện thoại.
        //
        //
        public ActionResult Index(string name, string error)
        {
           
                ViewBag.CusError = error;
                var model = dbCus.Customers.ToList();// Lấy danh sách tất cả khách hàng hiện tại từ dbCus.Customers.ToList();
            if (!string.IsNullOrEmpty(name)) //Kiểm tra xem tham số tìm kiếm "name" có rỗng hay không
            {
                    model = model.Where(p => p.cusPhone.Contains(name)).ToList(); //nếu có truy vấn sẽ được thực hiện, lấy ra danh sách các khách hàng chứa số điện thoại trùng khớp với name. 
            }
                return View(model);// Trả về danh sách khách hàng model được truy vấn
            }
        
    }
}