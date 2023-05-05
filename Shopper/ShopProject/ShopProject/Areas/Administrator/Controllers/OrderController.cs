using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class OrderController : Controller
    {
        Models.AdminContext dbOrder = new Models.AdminContext(); //Khởi tạo mới một đối tượng AdminContext để quản lý cơ sở dữ liệu về Order (đặt hàng).
        // GET: Administrator/Order
        public ActionResult Index(int ?page)
        {
            if (page == null) page = 1; //Kiểm tra xem tham số truyền vào của trang (page) có bằng null hay không. Nếu bằng null, phần tử page sẽ được gán giá trị mặc định bằng 1.
            var sp = dbOrder.OrderDetails.OrderBy(x => x.orderID);
            //Lấy tất cả các chi tiết đơn hàng (OrderDetails) từ đối tượng quản lý cơ sở dữ liệu được sắp xếp theo thứ tự orderID.

            int pageSize = 100;
            int pageNumber = (page ?? 1);
            //  Khai báo kích thước trang (pageSize) để phân trang và mã hiện tại của trang (pageNumber) 
            // sử dụng toán tử coalescing. Nếu pageNumber không tồn tại, nó sẽ được gán bằng 1.
            //

            return View(sp.ToPagedList(pageNumber, pageSize));

        
        }
    }
}