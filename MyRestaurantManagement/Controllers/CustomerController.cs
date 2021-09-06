using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyRestaurantManagement.Data;
using MyRestaurantManagement.Models;

namespace MyRestaurantManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyDbContext _dbCtx;
        private Int64 RestaurantID;

        public CustomerController(MyDbContext dbCtx,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _dbCtx = dbCtx;
            RestaurantID = config.GetValue<Int64>("AppSettings:RestaurantID");
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Menu")]
        public IActionResult Menu()
        {
            MenuViewModel model = new MenuViewModel(_dbCtx);
            model.RestaurantID = RestaurantID;
            model.LoadData();
            return View(model);
        }

        [Route("Order/{OrderID}")]
        public IActionResult Order(long OrderID)
        {
            CustomerOrderModel customerOrderModel = _dbCtx.CustomerOrders.Find(OrderID);
            customerOrderModel.OrderItems = _dbCtx.OrderItems.ToList().Where(o => o.OrderId == OrderID).ToList();

            customerOrderModel.OrderItems.ForEach(o =>
            {
                ProductModel product = _dbCtx.Products.Find(o.ProductId);
                o.ProductId = product.Id;
                o.ProductName = product.Name;
                o.TotalAmount = Convert.ToInt32(o.Quantity) * product.Price;

            });



            customerOrderModel.CustomerDetails = _dbCtx.Customers.Find(customerOrderModel.CustomerId);
            return View(customerOrderModel);
        }

        [Route("Menu")]
        [HttpPost]
        public IActionResult Menu(string productId, string quantity_)
        {
            ProductModel product = _dbCtx.Products.Find(Convert.ToInt64(productId));
            CustomerOrderModel customerModel = new CustomerOrderModel();

            OrderItemModel orderItem = new OrderItemModel();
            orderItem.ProductId = product.Id;
            orderItem.ProductName = product.Name;
            orderItem.Quantity = Convert.ToInt32(quantity_);
            orderItem.TotalAmount = Convert.ToInt32(quantity_) * product.Price;

            List<OrderItemModel> OrderItems = HttpContext.Session.GetObject<List<OrderItemModel>>(AppConstants.CurrentCartItems);

            if (OrderItems == null)
                OrderItems = new List<OrderItemModel>();

            if (OrderItems.Where(o => o.ProductId == orderItem.ProductId).Count() > 0)
            {
                var extOrderItem = OrderItems.Find(p => p.ProductId == orderItem.ProductId);
                extOrderItem.Quantity = extOrderItem.Quantity + orderItem.Quantity;
                extOrderItem.TotalAmount = extOrderItem.Quantity * product.Price;

            }
            else
                OrderItems.Add(orderItem);

            HttpContext.Session.SetObject(AppConstants.CurrentCartItems, OrderItems);
            HttpContext.Session.SetString(AppConstants.CurrentCartItemsCount, Convert.ToString(OrderItems.Count()));

            MenuViewModel model = new MenuViewModel(_dbCtx);
            model.RestaurantID = RestaurantID;
            model.LoadData();
            return View(model);
        }
    }
}
