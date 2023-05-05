namespace ShopProject.Areas.Administrator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int commentID { get; set; }

        [StringLength(50)]
        public string proID { get; set; }

        public string commentMessage { get; set; }

        public virtual Product Product { get; set; }
    }
}
