﻿// <auto-generated />
using System;
using BigBazzar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigBazzar.Migrations
{
    [DbContext(typeof(BigBazzarContext))]
    [Migration("20220805111842_migr 2")]
    partial class migr2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BigBazzar.Models.Carts", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BigBazzar.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BigBazzar.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("BigBazzar.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<int?>("OrderMasterId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("ProductQuantity")
                        .HasColumnType("real");

                    b.Property<float>("ProductRate")
                        .HasColumnType("real");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderMasterId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BigBazzar.Models.OrderMasters", b =>
                {
                    b.Property<int>("OrderMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderMasterId"), 1L, 1);

                    b.Property<float>("AmountPaid")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderDate")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("OrderMasterId");

                    b.HasIndex("CustomerId");

                    b.ToTable("OrderMasters");
                });

            modelBuilder.Entity("BigBazzar.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BigBazzar.Models.Carts", b =>
                {
                    b.HasOne("BigBazzar.Models.Customers", "Customers")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId");

                    b.HasOne("BigBazzar.Models.Products", "Products")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId");

                    b.Navigation("Customers");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BigBazzar.Models.Feedback", b =>
                {
                    b.HasOne("BigBazzar.Models.Customers", "Customers")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId");

                    b.HasOne("BigBazzar.Models.Products", "Products")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProductId");

                    b.Navigation("Customers");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BigBazzar.Models.OrderDetails", b =>
                {
                    b.HasOne("BigBazzar.Models.OrderMasters", "OrderMasters")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderMasterId");

                    b.HasOne("BigBazzar.Models.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("OrderMasters");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BigBazzar.Models.OrderMasters", b =>
                {
                    b.HasOne("BigBazzar.Models.Customers", "Customers")
                        .WithMany("OrderMasters")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("BigBazzar.Models.Customers", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Feedbacks");

                    b.Navigation("OrderMasters");
                });

            modelBuilder.Entity("BigBazzar.Models.OrderMasters", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BigBazzar.Models.Products", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Feedbacks");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}