namespace ShopProject.Areas.Administrator.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdminContext : DbContext
    {
        public AdminContext()
            : base("name=AdminContext")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.adAcc)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.adPass)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.cusEmail)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ordtsThanhTien)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.orderDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.pdcPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.pdcEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.proSize)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.proPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.proUpdateDate)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Rate)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Rate>()
                .Property(e => e.proID)
                .IsUnicode(false);
        }
    }
}
