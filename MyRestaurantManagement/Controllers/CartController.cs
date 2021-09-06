using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyRestaurantManagement.Data;
using MyRestaurantManagement.Models;
using MyRestaurantManagement.Services;

namespace MyRestaurantManagement.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _dbCtx;
        private Int64 RestaurantID;

        public CartController(MyDbContext dbCtx,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _dbCtx = dbCtx;
            RestaurantID = config.GetValue<Int64>("AppSettings:RestaurantID");
        }

        // GET: CartController
        public ActionResult Index()
        {
            CustomerOrderModel model = new CustomerOrderModel();
            List<OrderItemModel> OrderItems = HttpContext.Session.GetObject<List<OrderItemModel>>(AppConstants.CurrentCartItems);

            if (OrderItems != null)
            {
                model.OrderItems = OrderItems;
                return View(model);
            }
            return RedirectToAction("Menu", "Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(IFormCollection collection)
        {
            try
            {
                CustomerOrderModel model = new CustomerOrderModel();

                List<OrderItemModel> OrderItems = HttpContext.Session.GetObject<List<OrderItemModel>>(AppConstants.CurrentCartItems);
                model.CustomerDetails = new CustomerModel();
                model.CustomerDetails.Firstname = collection["CustomerDetails.Firstname"].ToString();
                model.CustomerDetails.Contact = Convert.ToInt64(collection["CustomerDetails.Contact"]);
                model.CustomerDetails.Address = collection["CustomerDetails.Address"].ToString();

                var card = collection["card"].ToString();

                model.CustomerDetails.NameOnCard = collection["CustomerDetails.NameOnCard"].ToString();
                model.CustomerDetails.CardNumber = Convert.ToInt64(collection["CustomerDetails.CardNumber"]);
                model.CustomerDetails.ExpiryMonth = Convert.ToInt32(collection["CustomerDetails.ExpiryMonth"]);
                model.CustomerDetails.ExpiryYear = Convert.ToInt32(collection["CustomerDetails.ExpiryYear"]);
                model.CustomerDetails.CVV = collection["CustomerDetails.CVV"].ToString();

                var customerModel = _dbCtx.Customers.Add(model.CustomerDetails);
                _dbCtx.SaveChanges();

                model.CustomerId = Convert.ToInt64(customerModel.Property("Id").CurrentValue);
                model.Rate = OrderItems.Sum(o => o.TotalAmount);
                model.OrderCreationDate = DateTime.Now;
                model.OrderStatusId = 1;

                var customerOrderModel = _dbCtx.CustomerOrders.Add(model);
                _dbCtx.SaveChanges();

                var OrderId = Convert.ToInt64(customerOrderModel.Property("Id").CurrentValue);
                model.Id = OrderId;

                foreach (var orderItem in OrderItems)
                {
                    orderItem.OrderId = OrderId;
                    var orderItemModel = _dbCtx.OrderItems.Add(orderItem);
                    _dbCtx.SaveChanges();
                }

                PaymentGateway paymentgateway = new PaymentGateway();
                paymentgateway.MakePayment(model.CustomerDetails.NameOnCard, model.CustomerDetails.CardNumber, model.CustomerDetails.ExpiryMonth,
                    model.CustomerDetails.ExpiryYear, model.CustomerDetails.CVV);

                if(paymentgateway.PaymentID != null)
                {
                    model.OrderStatusId = 4;
                    model.PaymentID = paymentgateway.PaymentID.ToString();
                    _dbCtx.CustomerOrders.Update(model);
                    _dbCtx.SaveChanges();
                }

                HttpContext.Session.SetObject(AppConstants.CurrentCartItems, null);
                HttpContext.Session.SetString(AppConstants.CurrentCartItemsCount, "0");

                return RedirectToAction("Order", "Customer", new { OrderID = OrderId });
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CartChange(IFormCollection collection)
        {
            try
            {
                var quantity_ = collection["quantity_"].ToString();
                var productId = collection["productId"].ToString();
                CustomerOrderModel model = new CustomerOrderModel();
                ProductModel product = _dbCtx.Products.Find(Convert.ToInt64(productId));
                List<OrderItemModel> OrderItems = HttpContext.Session.GetObject<List<OrderItemModel>>(AppConstants.CurrentCartItems);

                if (OrderItems != null)
                {
                    var orderItem = OrderItems.Find(p => p.ProductId == Convert.ToInt64(productId));
                    orderItem.Quantity = Convert.ToInt32(quantity_);
                    orderItem.TotalAmount = Convert.ToInt32(quantity_) * product.Price;

                    HttpContext.Session.SetObject(AppConstants.CurrentCartItems, OrderItems);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Remove(int id)
        {
            List<OrderItemModel> OrderItems = HttpContext.Session.GetObject<List<OrderItemModel>>(AppConstants.CurrentCartItems);

            if (OrderItems != null)
            {
                var orderItem = OrderItems.Find(p => p.ProductId == Convert.ToInt64(id));
                OrderItems.Remove(orderItem);
                HttpContext.Session.SetObject(AppConstants.CurrentCartItems, OrderItems);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
