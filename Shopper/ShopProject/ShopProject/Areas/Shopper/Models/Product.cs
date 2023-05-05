namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [StringLength(50)]
        public string proID { get; set; }

        public int? pdcID { get; set; }

        public int? typeID { get; set; }

        [StringLength(200)]
        public string proName { get; set; }

        [StringLength(10)]
        public string proSize { get; set; }

        [StringLength(10)]
        public string proPrice { get; set; }

        public int? proDiscount { get; set; }

        public string proPhoto { get; set; }

        [StringLength(50)]
        public string proUpdateDate { get; set; }

        public string proDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual Rate Rate { get; set; }
    }
}
