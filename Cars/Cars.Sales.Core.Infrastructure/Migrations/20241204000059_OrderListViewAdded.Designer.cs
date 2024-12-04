﻿// <auto-generated />
using System;
using Cars.Sales.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cars.Sales.Core.Infrastructure.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    [Migration("20241204000059_OrderListViewAdded")]
    partial class OrderListViewAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sales")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Offers", "sales");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("money");

                    b.Property<DateTime?>("PlannedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders", "sales");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.OrderComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderComments", "sales");
                });

            modelBuilder.Entity("Cars.SharedKernel.Sales.ViewModels.OrderListViewModel", b =>
                {
                    b.Property<int>("Comments")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("money");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("OrderListView", "sales");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.Offer", b =>
                {
                    b.OwnsOne("Cars.Sales.Core.Domain.ValueObjects.CarConfiguration", "Configuration", b1 =>
                        {
                            b1.Property<Guid>("OfferId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Color")
                                .HasColumnType("int");

                            b1.Property<int>("GearboxType")
                                .HasColumnType("int");

                            b1.Property<string>("Model")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Version")
                                .HasColumnType("int");

                            b1.HasKey("OfferId");

                            b1.ToTable("Offers", "sales");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");

                            b1.OwnsOne("Cars.Sales.Core.Domain.ValueObjects.Engine", "Engine", b2 =>
                                {
                                    b2.Property<Guid>("CarConfigurationOfferId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Capacity")
                                        .HasColumnType("int");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Type")
                                        .HasColumnType("int");

                                    b2.HasKey("CarConfigurationOfferId");

                                    b2.ToTable("Offers", "sales");

                                    b2.WithOwner()
                                        .HasForeignKey("CarConfigurationOfferId");
                                });

                            b1.Navigation("Engine");
                        });

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("Cars.Sales.Core.Domain.ValueObjects.CarConfiguration", "Configuration", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<int>("Color")
                                .HasColumnType("int");

                            b1.Property<int>("GearboxType")
                                .HasColumnType("int");

                            b1.Property<string>("Model")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Version")
                                .HasColumnType("int");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "sales");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsOne("Cars.Sales.Core.Domain.ValueObjects.Engine", "Engine", b2 =>
                                {
                                    b2.Property<int>("CarConfigurationOrderId")
                                        .HasColumnType("int");

                                    b2.Property<int>("Capacity")
                                        .HasColumnType("int");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Type")
                                        .HasColumnType("int");

                                    b2.HasKey("CarConfigurationOrderId");

                                    b2.ToTable("Orders", "sales");

                                    b2.WithOwner()
                                        .HasForeignKey("CarConfigurationOrderId");
                                });

                            b1.Navigation("Engine");
                        });

                    b.OwnsOne("Cars.Sales.Core.Domain.ValueObjects.Customer", "Customer", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "sales");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Configuration");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.OrderComment", b =>
                {
                    b.HasOne("Cars.Sales.Core.Domain.Entities.Order", "Order")
                        .WithMany("Comments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Cars.Sales.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
