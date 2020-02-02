using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlessDiamond.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<Sale> Sales { get; set; }
    }
    public class Buyer
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public Int64 PhoneNumber { get; set; }
        public List<Sale> Sales { get; set; }

    }
    public class Sale
    {
        //public int SaleId { get; set; }
        public DateTime DateOfSale { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Buyer Buyer { get; set; }
        public int BuyerId { get; set; }
        public List<History> History { get; set; }

    }
    public class History
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int SaleBuyerId { get; set; }
        public int SaleProductId { get; set; }
    }

    public class BlessDiamondContextFactory : IDesignTimeDbContextFactory<BlessDiamondContext>
    {
        public BlessDiamondContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}BlessDiamond.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();
            return new BlessDiamondContext(config.GetConnectionString("ConStr"));
        }
    }


    public class BlessDiamondContext : DbContext
    {
        private string _connectionString;

        public BlessDiamondContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
        public DbSet<History> History { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Taken from here:
            //https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

            //set up composite primary key
            modelBuilder.Entity<Sale>()
                .HasKey(qt => new { qt.ProductId, qt.BuyerId });

            //set up foreign key from QuestionsTags to Questions
            modelBuilder.Entity<Sale>()
                .HasOne(qt => qt.Product)
                .WithMany(q => q.Sales)
                .HasForeignKey(q => q.ProductId);

            //set up foreign key from QuestionsTags to Tags
            modelBuilder.Entity<Sale>()
                .HasOne(qt => qt.Buyer)
                .WithMany(t => t.Sales)
                .HasForeignKey(q => q.BuyerId);

           
        }

    }
}

