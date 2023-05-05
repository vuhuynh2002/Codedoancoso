namespace ShopProject.Areas.Administrator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string proID { get; set; }

        public int? ordtsQuantity { get; set; }

        [StringLength(50)]
        public string ordtsThanhTien { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
