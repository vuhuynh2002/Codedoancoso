using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Areas.Shopper.Models
{
    public class CartItem
    {
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh { get; set; }
        public string DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get
            {
                return SoLuong * Int32.Parse(DonGia);
            }
        }
    }
}