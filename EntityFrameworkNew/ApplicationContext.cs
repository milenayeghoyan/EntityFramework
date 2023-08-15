using EntityFrameworkNew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNew
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer2> Customers2 => Set<Customer2>();
        public DbSet<Product> products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<NewCustomer> NewCustomers => Set<NewCustomer>();
        public DbSet< FeaturedProduct> featuredProducts => Set<FeaturedProduct>();
        public DbSet<BestSellerProduct> bestSellerProducts => Set<BestSellerProduct>();
        public DbSet<CancelledOrder> cancelledOrders => Set<CancelledOrder>();
        public DbSet<CallDetail> callDetails => Set<CallDetail>();  
        public DbSet<OrderItem> orderItems => Set<OrderItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer2>()
                .HasMany(Customer2 => Customer2.Orders)         
                .WithOne(Order => Order.Customer)       
                .HasForeignKey(Order => Order.Customerld);
            
            modelBuilder.Entity<Customer2>()
            .HasAlternateKey(c => c.Email);


            modelBuilder.Entity<Product>()
                .HasOne(Product => Product.productDetails)
                .WithOne(ProductDetails => ProductDetails.product)
                .HasForeignKey<ProductDetails>(pd => pd.ProductId);
            
            
            modelBuilder.Entity<Product>().HasCheckConstraint("CK_Products_StockQuantity", "[StockQuantity] >= 0");

          
            modelBuilder.Entity<Order>()
                .HasIndex(e => e.OrderDate).IsClustered(false);

            
            modelBuilder.Entity<Order>()
                .HasIndex(e => new { e.Customerld, e.Status })
                .IsClustered(false);
            
                

            modelBuilder.Entity<Product>()
           .HasKey(p => p.Productid);


            modelBuilder.Entity<Order>()
          .HasMany(o => o.OrderItems)
          .WithOne(oi => oi.Order)
          .HasForeignKey(oi => oi.OrderID);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductID);



            base.OnModelCreating(modelBuilder);
        }



        public ApplicationContext() : base() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-A9NSD87V23T\MSSQLSERVER01;Database=CustomersdbNew;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
