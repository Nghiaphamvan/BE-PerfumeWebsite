﻿// <auto-generated />
using System;
using BackEndv2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndv2.Migrations
{
    [DbContext(typeof(PerfumeDetailContext))]
    partial class PerfumeDetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndv2.Data.Campaign", b =>
                {
                    b.Property<int>("CampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignID"));

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("nameCampaign")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignID");

                    b.HasIndex("id");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("BackEndv2.Data.Categories", b =>
                {
                    b.Property<int>("categoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoriID"));

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("categoriID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BackEndv2.Data.Customer", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerID"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("customerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BackEndv2.Data.Order", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderID"));

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("totalAmount")
                        .HasColumnType("int");

                    b.HasKey("orderID");

                    b.HasIndex("customerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BackEndv2.Data.OrderDetail", b =>
                {
                    b.Property<int>("orderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderDetailID"));

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<int>("pricePerUnit")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("orderDetailID");

                    b.HasIndex("id");

                    b.HasIndex("orderID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("BackEndv2.Data.PaymentMethod", b =>
                {
                    b.Property<int>("paymentMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("paymentMethodID"));

                    b.Property<int>("cardNumber")
                        .HasColumnType("int");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<string>("expirationdate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentMethodID");

                    b.HasIndex("customerID");

                    b.ToTable("paymentMethod");
                });

            modelBuilder.Entity("BackEndv2.Data.PerfumeDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("brand")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pice")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("volume")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PerfumeDetail");
                });

            modelBuilder.Entity("BackEndv2.Data.Sale", b =>
                {
                    b.Property<int>("saleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("saleID"));

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("percent")
                        .HasColumnType("int");

                    b.HasKey("saleID");

                    b.HasIndex("id");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("BackEndv2.Data.ShippingAddress", b =>
                {
                    b.Property<int>("shippingAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("shippingAddressID"));

                    b.Property<string>("address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("city")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("shippingAddressID");

                    b.HasIndex("customerID");

                    b.ToTable("ShippingAddresses");
                });

            modelBuilder.Entity("BackEndv2.Data.Campaign", b =>
                {
                    b.HasOne("BackEndv2.Data.PerfumeDetail", "PerfumeDetails")
                        .WithMany("Campaign")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfumeDetails");
                });

            modelBuilder.Entity("BackEndv2.Data.Order", b =>
                {
                    b.HasOne("BackEndv2.Data.Customer", "customer")
                        .WithMany("Orders")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("BackEndv2.Data.OrderDetail", b =>
                {
                    b.HasOne("BackEndv2.Data.PerfumeDetail", "ids")
                        .WithMany("OrderDetail")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndv2.Data.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ids");
                });

            modelBuilder.Entity("BackEndv2.Data.PaymentMethod", b =>
                {
                    b.HasOne("BackEndv2.Data.Customer", "customer")
                        .WithMany("paymentMethods")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("BackEndv2.Data.Sale", b =>
                {
                    b.HasOne("BackEndv2.Data.PerfumeDetail", "PerfumeDetails")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfumeDetails");
                });

            modelBuilder.Entity("BackEndv2.Data.ShippingAddress", b =>
                {
                    b.HasOne("BackEndv2.Data.Customer", "customer")
                        .WithMany("ShippingAddresss")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("BackEndv2.Data.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ShippingAddresss");

                    b.Navigation("paymentMethods");
                });

            modelBuilder.Entity("BackEndv2.Data.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BackEndv2.Data.PerfumeDetail", b =>
                {
                    b.Navigation("Campaign");

                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
