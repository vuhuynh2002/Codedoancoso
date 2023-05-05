using ShopProject.Areas.Shopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class GioHangController : Controller
    {
        UserContext db = new UserContext();// tạo một đối tượng `UserContext` để kết nối tới cơ sở dữ liệu.


        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>; //tạo một danh sách các đối tượng `CartItem` mục giỏ hàng từ giỏ hàng được lưu trong Session.
            return View(giohang);// trả về một view để hiển thị danh sách các đối tượng `CartItem` trong giỏ hàng.Danh sách sản phẩm được truyền qua biến model `giohang` và sẽ được sử dụng để hiển thị trong view.

        }
        public ActionResult ThemVaoGio(string SanPhamID) //đây là khai báo hàm cùng với tham số đầu vào `SanPhamID`.
        {
            if (Session["giohang"] == null) // trong trường hợp không có giỏ hàng nào được tạo (giỏ hàng chưa được lưu vào Session), điều kiện này sẽ được thực thi.


            {
                Session["giohang"] = new List<CartItem>();// nếu không tìm thấy giỏ hàng trong Session, thì Session sẽ được khởi tạo với một List rỗng của lớp `CartItem`.
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // tạo một danh sách các đối tượng `CartItem` từ giỏ hàng lấy ra từ session.



            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null) //kiểm tra sản phẩm được thêm vào có trong giỏ hàng hay không. Nếu không tìm thấy sản phẩm nào trong giỏ hàng, điều kiện này sẽ được thực thi.
                                                                               //Trả về phần tử đầu tiên của một chuỗi hoặc giá trị mặc định nếu không tìm thấy phần tử nào.

            {
                Models.Product sp = db.Products.Find(SanPhamID); //tìm sản phẩm trong cơ sở dữ liệu với `SanPhamID` tương ứng. 

                CartItem newItem = new CartItem()
                {
                    SanPhamID = SanPhamID,
                    TenSanPham = sp.proName,
                    SoLuong = 1,
                    Hinh = sp.proPhoto,
                    DonGia = (Int32.Parse(sp.proPrice) - (Int32.Parse(sp.proPrice) * sp.proDiscount) / 100).ToString()

                };
                //Tạo một đối tượng `CartItem` mới với thông tin chi tiết của sản phẩm được chọn để thêm vào giỏ hàng (Cuối cùng đối tượng mới này được thêm vào danh sách giỏ hàng).
                giohang.Add(newItem); //thêm đối tượng mới vào danh sách giỏ hàng (nếu sản phẩm này không có trong giỏ hàng trước đấy).
            }
            else
            {
               
                CartItem cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }

           
            return Redirect(Request.UrlReferrer.ToString());
        }
    
        public ActionResult SuaSoLuong(string SanPhamID, int soluongmoi)
        {
         
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  //: tạo một danh sách các đối tượng `CartItem` từ giỏ hàng được lưu trong Session.
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));//tìm kiếm sản phẩm phù hợp trong danh sách giỏ hàng thông qua `SanPhamID`.
            if (itemSua != null)// kiểm tra nếu sản phẩm được tìm thấy trong giỏ hàng.
            {
                if (soluongmoi < 1 || soluongmoi > 100) // kiểm tra giá trị số lượng mới của sản phẩm. Nếu giá trị này nhỏ hơn 1 hoặc lớn hơn 100, điều kiện thực thi sẽ được thực hiện.
                {

                }
                else
                {
                    @ViewBag.GioError = ""; //cập nhật giá trị cho biến `ViewBag` để hiển thị thông báo không có lỗi gì xảy ra trong quá trình cập nhật giỏ hàng.
                    itemSua.SoLuong = soluongmoi; //cập nhật số lượng sản phẩm trong đối tượng `CartItem` phù hợp với giá trị số lượng mới.
                }
            }
            return RedirectToAction("Index");// quay lại Index view và hiển thị giỏ hàng đã được cập nhật mới.

        }
      
        public ActionResult XoaKhoiGio(string SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>; // tạo một danh sách các đối tượng `CartItem` từ giỏ hàng được lưu trong Session.


            CartItem itemXoa = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));  //tìm kiếm sản phẩm phù hợp trong danh sách giỏ hàng thông qua `SanPhamID`.
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
    }
}