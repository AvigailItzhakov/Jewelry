using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlessDiamond.Web.Models;
using BlessDiamond.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BlessDiamond.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _enviorment;
        private string _connectionString;
        public HomeController(IHostingEnvironment enviornment, IConfiguration configuration)
        {
            _enviorment = enviornment;
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSale(Product product, Buyer buyer, History history)
        {
            var db = new BlessDiamondRepository(_connectionString);
            db.AddSale(product,buyer, history);

            return Redirect("/home/ViewAllSales");
        }
        public IActionResult ViewAllSales()
        {
            var db = new BlessDiamondRepository(_connectionString);
            
            return View(db.GetAllSales());

        }

        public IActionResult ViewSale(int id)
        {
            var db = new BlessDiamondRepository(_connectionString);
            return View(db.GetSale(id));
        }
        [HttpPost]
        public IActionResult AddPayment( int id, decimal amount)
        {
            var db = new BlessDiamondRepository(_connectionString);
            db.AddPayment(id, amount);
            return Json(DateTime.Now);
        }

    }
}
