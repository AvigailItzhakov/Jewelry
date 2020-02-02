using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Text;


namespace BlessDiamond.Data
{
    public class BlessDiamondRepository
    {
        private string _connectionString;
        public BlessDiamondRepository(string connectionString)
        {
            _connectionString = connectionString;

        }
        public void AddSale(Product product, Buyer buyer, History history)
        {
            using (var context = new BlessDiamondContext(_connectionString))
            {
                context.Products.Add(product);
                Buyer b= context.Buyers.FirstOrDefault(i => i.BuyerName == buyer.BuyerName);
                if (b!=null)
                {
                    buyer.Id = b.Id;
                }
                else
                {
                    context.Buyers.Add(buyer);
                }
                Sale sale = new Sale
                {
                    DateOfSale = DateTime.Now,
                    BuyerId = buyer.Id,
                    ProductId = product.Id
                };
                context.Sales.Add(sale);
                History h = new History
                {
                    Date = DateTime.Now,
                    Amount = history.Amount,
                    SaleProductId = product.Id,
                    SaleBuyerId= buyer.Id
                };
                context.History.Add(h);

                context.SaveChanges();
            }
        }

   public IEnumerable<Sale> GetAllSales()
        {
            using (var context = new BlessDiamondContext(_connectionString))
            {
                var s = context.Sales.ToArray();
                foreach (Sale sale in s)
                {
                    sale.Buyer = context.Buyers.FirstOrDefault(b => b.Id == sale.BuyerId);
                    sale.Product = context.Products.FirstOrDefault(p => p.Id == sale.ProductId);
                }
                return s;
            }

        }
        public Sale GetSale (int id)
        {

            using (var context = new BlessDiamondContext(_connectionString))
            {
                var s = context.Sales.FirstOrDefault(i => i.ProductId == id);
                s.Buyer = context.Buyers.FirstOrDefault(b => b.Id == s.BuyerId);
                s.Product = context.Products.FirstOrDefault(p => p.Id == s.ProductId);
                s.History = context.History.Where(h => h.SaleProductId == id).ToList();
                return s;

            }
        }
        public void AddPayment (int id, decimal amount)
        {
            using (var context = new BlessDiamondContext(_connectionString))
            {
                History h = new History();
                h.Amount = amount;
                h.Date = DateTime.Now;
                h.SaleProductId = id;
                context.History.Add(h);
                context.SaveChanges();
            }
        }
    }
}
