﻿// <auto-generated />
using System;
using BlessDiamond.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlessDiamond.Data.Migrations
{
    [DbContext(typeof(BlessDiamondContext))]
    partial class BlessDiamondContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlessDiamond.Data.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerName");

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("BlessDiamond.Data.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("SaleBuyerId");

                    b.Property<int>("SaleProductId");

                    b.HasKey("Id");

                    b.HasIndex("SaleProductId", "SaleBuyerId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("BlessDiamond.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductName");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BlessDiamond.Data.Sale", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("BuyerId");

                    b.Property<DateTime>("DateOfSale");

                    b.HasKey("ProductId", "BuyerId");

                    b.HasIndex("BuyerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("BlessDiamond.Data.History", b =>
                {
                    b.HasOne("BlessDiamond.Data.Sale")
                        .WithMany("History")
                        .HasForeignKey("SaleProductId", "SaleBuyerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlessDiamond.Data.Sale", b =>
                {
                    b.HasOne("BlessDiamond.Data.Buyer", "Buyer")
                        .WithMany("Sales")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlessDiamond.Data.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
