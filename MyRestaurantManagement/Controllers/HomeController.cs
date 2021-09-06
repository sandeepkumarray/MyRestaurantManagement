using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyRestaurantManagement.Data;
using MyRestaurantManagement.Models;

namespace MyRestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext _dbCtx;
        private Int64 RestaurantID;
       
        public HomeController(ILogger<HomeController> logger, Microsoft.Extensions.Configuration.IConfiguration config, MyDbContext dbCtx)
        {
            _logger = logger;
            _dbCtx = dbCtx;
            RestaurantID = config.GetValue<Int64>("AppSettings:RestaurantID");
        }

        public IActionResult Index()
        {
            RestaurantModel model = _dbCtx.Restaurants.Find(Convert.ToInt64(1));
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
