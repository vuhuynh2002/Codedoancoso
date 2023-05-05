using ShopProject.Areas.Shopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class ThanhToanController : Controller
    {
        UserContext db = new UserContext();
        // GET: Shopper/ThanhToan
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

       [HttpPost]
        public ActionResult StepEnd()
        // Hành động này được gọi sau khi người dùng hoàn thành quá trình đặt hàng và đã điền đầy đủ thông tin giao hàng.

        {
            //Khởi tạo biến phone, fullname, email, address, note từ dữ liệu được gửi lên thông qua phương thức POST của Form.

            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];


            //Tìm khách hàng có số điện thoại tương ứng trong CSDL. Nếu khách hàng có trong CSDL,
            //thông tin của khách hàng đó được cập nhật theo thông tin được người dùng gửi lên.
            //Ngược lại, nếu khách hàng không có, tạo khách hàng mới và thêm vào CSDL.
            //

            //

            Customer newCus = new Customer();
            var cus = db.Customers.FirstOrDefault(p => p.cusPhone.Equals(phone));
            if (cus != null)
            {
             
                cus.cusFullName = fullname;
                cus.cusEmail = email;
                cus.cusAddress = address;
                db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //Nếu khách hàng đã có trong CSDL, cập nhật thông tin mới vào CSDL bằng cách
                //gán thông tin mới vào đối tượng khách hàng lấy từ CSDL và chỉ định rằng đối tượng này đã bị thay đổi 
                //(EntityState.Modified)và lưu lại thông tin vào CSDL.
                //


            }
            else
            {
           
                newCus.cusPhone = phone;
                newCus.cusFullName = fullname;
                newCus.cusEmail = email;
                newCus.cusAddress = address;
                db.Customers.Add(newCus);
                db.SaveChanges();

                //Trường hợp không tìm thấy khách hàng nào cùng số điện thoại trong CSDL, 
                // tạo đối tượng khách hàng mới với thông tin được người dùng gửi lên và lưu đối tượng này vào CSDL.
                //
                //
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            //Lấy ra giỏ hàng được lưu trữ trong Session với khóa "giohang" dưới dạng List<CartItem>.
            //thêm order mới
            Order newOrder = new Order();// 
            string newIDOrder = (Int32.Parse( db.Orders.OrderByDescending(p => p.orderDateTime).FirstOrDefault().orderID.Replace("HD", "")) + 1).ToString();
            newOrder.orderID = "HD" + newIDOrder;
            newOrder.cusPhone = phone;
            newOrder.orderMessage = note;
            newOrder.orderDateTime = DateTime.Now.ToString();
            newOrder.orderStatus = "0";
            db.Orders.Add(newOrder);
            db.SaveChanges();
            //thêm details
            for (int i = 0; i < giohang.Count; i++)
            {
                OrderDetail newOrdts = new OrderDetail();
                newOrdts.orderID = newOrder.orderID;
                newOrdts.proID = giohang.ElementAtOrDefault(i).SanPhamID;
                newOrdts.ordtsQuantity = giohang.ElementAtOrDefault(i).SoLuong;
                newOrdts.ordtsThanhTien = giohang.ElementAtOrDefault(i).ThanhTien.ToString();
                db.OrderDetails.Add(newOrdts);
                db.SaveChanges();
            }
            Session["MHD"] = "HD" + newIDOrder;
            Session["Phone"] = phone;
            // Lưu thông tin mã đơn hàng và số điện thoại của khách hàng vào Session để truyền cho trang kết quả đặt hàng.
            //xoá sạch giỏ hàng
            giohang.Clear();
            return RedirectToAction("HoaDon", "ThanhToan",new { area="Shopper"});
        }

        public ActionResult HoaDon()
        {
            return View();
        }

    }
}
 