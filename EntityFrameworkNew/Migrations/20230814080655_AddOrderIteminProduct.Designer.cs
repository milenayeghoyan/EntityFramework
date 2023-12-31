﻿// <auto-generated />
using System;
using EntityFrameworkNew;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkNew.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230814080655_AddOrderIteminProduct")]
    partial class AddOrderIteminProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkNew.Models.BestSellerProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("StockQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("ProductDetailsId");

                    b.ToTable("bestSellerProducts");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.CallDetail", b =>
                {
                    b.Property<int>("CallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallID"));

                    b.Property<decimal>("CallDuration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CallerNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecieverNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallID");

                    b.ToTable("callDetails");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.CancelledOrder", b =>
                {
                    b.Property<int>("Orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Orderid"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Customerld")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Orderid");

                    b.HasIndex("CustomerId");

                    b.ToTable("cancelledOrders");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Customer2", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasAlternateKey("Email");

                    b.ToTable("Customers2");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.FeaturedProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("StockQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("ProductDetailsId");

                    b.ToTable("featuredProducts");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.NewCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewCustomers");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Order", b =>
                {
                    b.Property<int>("Orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Orderid"));

                    b.Property<int>("Customerld")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Orderid");

                    b.HasIndex("OrderDate");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("OrderDate"), false);

                    b.HasIndex("Customerld", "Status");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Customerld", "Status"), false);

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("orderItems");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Productid"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StockQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Productid");

                    b.ToTable("products", t =>
                        {
                            t.HasCheckConstraint("CK_Products_StockQuantity", "[StockQuantity] >= 0");
                        });
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.ProductDetails", b =>
                {
                    b.Property<int>("ProductDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailsId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.BestSellerProduct", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.ProductDetails", "productDetails")
                        .WithMany()
                        .HasForeignKey("ProductDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productDetails");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.CancelledOrder", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.Customer2", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.FeaturedProduct", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.ProductDetails", "productDetails")
                        .WithMany()
                        .HasForeignKey("ProductDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productDetails");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Order", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.Customer2", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("Customerld")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.OrderItem", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkNew.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.ProductDetails", b =>
                {
                    b.HasOne("EntityFrameworkNew.Models.Product", "product")
                        .WithOne("productDetails")
                        .HasForeignKey("EntityFrameworkNew.Models.ProductDetails", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Customer2", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EntityFrameworkNew.Models.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("productDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
