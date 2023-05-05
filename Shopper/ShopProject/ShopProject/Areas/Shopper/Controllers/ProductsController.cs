using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class ProductsController : Controller
    {
        Models.UserContext db = new Models.UserContext(); // ạo một đối tượng context để thực hiện các thao tác đến CSDL.   

        public ActionResult ProductsByProType(int id, int? page) //  Đây là phương thức xử lý hiển thị các sản phẩm thuộc loại sản phẩm được cung cấp. `id` là id của loại sản phẩm và `page` là số trang sản phẩm được yêu cầu.
        {
            ViewBag.typeName = db.ProductTypes.SingleOrDefault(t => t.typeID == id).typeName; //  Gán tên loại sản phẩm cho biến `typeName` trong `ViewBag`. Tên loại sản phẩm sẽ được sử dụng để hiển thị tiêu đề trang.


            int pageSize = 8; // Đặt giá trị số sản phẩm được hiển thị trên mỗi trang là 8.
            int pageNumber = (page ?? 1); // Xác định số trang được yêu cầu nếu có.
            return View(db.Products.Where(t => t.typeID == id).OrderByDescending(x => x.typeID).ToPagedList(pageNumber, pageSize));
            //  Thực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm của loại sản phẩm cung cấp từ `id`. Danh sách sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo id giảm dần của các sản phẩm tương ứng trong danh sách.


        }

        public ActionResult ProductsByPdc(int id, int? page) // Đây là phương thức xử lý hiển thị các sản phẩm thuộc nhà sản xuất được cung cấp. `id` là id của nhà sản xuất và `page` là số trang sản phẩm được yêu cầu.
        {
            ViewBag.pdcName = db.Producers.SingleOrDefault(c=>c.pdcID == id).pdcName; // Gán tên nhà sản xuất cho biến `pdcName` trong `ViewBag`. Tên nhà sản xuất sẽ được sử dụng để hiển thị tiêu đề trang.
            int pageSize = 8; // Đặt giá trị số sản phẩm được hiển thị trên mỗi trang là 8.
            int pageNumber = (page ?? 1);
            return View(db.Products.Where(p => p.pdcID == id).OrderByDescending(x=>x.pdcID).ToPagedList(pageNumber, pageSize));
            // hực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm của nhà sản xuất cung cấp từ `id`. Danh sách các sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo id giảm dần của các sản phẩm tương ứng trong danh sách.
        }

        public ActionResult SearchByName(string name, int? page)

        {
            ViewBag.search = name; // Gán từ khóa tìm kiếm cho biến `search` trong `ViewBag`. Từ khóa tìm kiếm sẽ được sử dụng để hiển thị tiêu đề trang.
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.Products.Where(p => p.proName.Contains(name)).OrderByDescending(x => x.proName).ToPagedList(pageNumber, pageSize));
            // Thực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm phù hợp với từ khóa tìm kiếm. Danh sách các sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo tên sản phẩm giảm dần của các sản phẩm tương ứng trong danh sách.
        }
        
        public ActionResult ProductsBytypeName(string name, int? page)
            //Đây là phương thức xử lý hiển thị các sản phẩm thuộc loại sản phẩm có tên được cung cấp. `name` là tên của loại sản phẩm và `page` là số trang sản phẩm được yêu cầu.

        {
            ViewBag.tName = name;//Gán tên loại sản phẩm cho biến `tName` trong `ViewBag`. Tên loại sản phẩm sẽ được sử dụng để hiển thị tiêu đề trang.
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.Products.Where(p => p.typeID == db.ProductTypes.FirstOrDefault(t=>t.typeName.Equals(name)).typeID).OrderByDescending(x => x.proUpdateDate).ToPagedList(pageNumber, pageSize));
            //Thực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm thuộc loại sản phẩm với tên là `name`. 
            //Danh sách các sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo ngày cập nhật giảm dần của các sản phẩm tương ứng trong danh sách.

        }

        public ActionResult ProductsBestNew(string title, int? page) 
        //Đây là phương thức xử lý hiển thị các sản phẩm mới nhất. Các sản phẩm sẽ được sắp xếp theo ngày cập nhật giảm dần.
        {
            ViewBag.titleDisplay = title;// Gán tiêu đề cho biến `titleDisplay` trong `ViewBag`.
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.Products.OrderByDescending(x => x.proUpdateDate).ToPagedList(pageNumber, pageSize));
            //Thực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm mới nhất. Danh sách các sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo ngày cập nhật giảm dần của các sản phẩm tương ứng trong danh sách.
        }

        public ActionResult ProductsBestDiscount(string title, int? page)
        //Đây là phương thức xử lý hiển thị các sản phẩm giảm giá. Các sản phẩm sẽ được sắp xếp theo phần trăm giảm giá giảm dần.


        {
            ViewBag.titleDisplayOfDis = title;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.Products.OrderByDescending(x => x.proDiscount).ToPagedList(pageNumber, pageSize));
            //Thực hiện việc tìm kiếm, lọc và sắp xếp các sản phẩm giảm giá. Danh sách các sản phẩm tìm thấy sẽ được đưa vào trang hiển thị dưới dạng một danh sách được phân trang. Sản phẩm sẽ được sắp xếp theo phần trăm giảm giá giảm dần của các sản phẩm tương ứng trong danh sách.

        }

        public ActionResult ProductDetail(string id)
        //Đây là phương thức hiển thị chi tiết của sản phẩm có `id` được cung cấp.
        {
            return View(db.Products.SingleOrDefault(p => p.proID.Equals(id)));
                                           
                                      //  `db.Products`: Lấy bảng sản phẩm từ cơ sở dữ liệu.



         //  `SingleOrDefault(p => p.proID.Equals(id)))`: Sử dụng phương thức SingleOrDefault() để lấy đối tượng sản phẩm có ID bằng với giá trị `id` được cung cấp.Nếu không tìm thấy sản phẩm nào có ID khớp, đối tượng Null sẽ được trả về.



                                    //    `return View(...)`: Trả về một View tức là một trang web chứa thông tin của đối tượng sản phẩm được tìm thấy trên trang web.
        }
    }
}