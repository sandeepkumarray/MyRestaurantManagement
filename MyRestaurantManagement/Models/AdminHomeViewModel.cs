using MyRestaurantManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Models
{
    public class AdminHomeViewModel
    {
        public List<OrderItemModel> OrderItems;
        public List<CustomerOrderModel> Orders;
        public List<CustomerModel> Customers;

        public List<OrderStatusModel> OrderStatuses;

        public List<MenuModel> Menues;
        public List<ProductModel> Products;
        public List<ProductCategoryModel> ProductCategories;
        public RestaurantModel restaurantModel;

        private readonly MyDbContext myDbContext;

        public AdminHomeViewModel(MyDbContext _myDbContext) : this()
        {
            myDbContext = _myDbContext;
        }

        public AdminHomeViewModel()
        {
            restaurantModel = new RestaurantModel();
            OrderStatuses = new List<OrderStatusModel>();

            Menues = new List<MenuModel>();
            ProductCategories = new List<ProductCategoryModel>();
            Products = new List<ProductModel>();

            Customers = new List<CustomerModel>();
            Orders = new List<CustomerOrderModel>();
            OrderItems = new List<OrderItemModel>();
        }

        public void LoadData()
        {
            restaurantModel = myDbContext.Restaurants.Find(Convert.ToInt64(1));
            OrderStatuses = myDbContext.OrderStatuses.ToList();
            Menues = myDbContext.Menues.ToList();
            ProductCategories = myDbContext.ProductCategories.ToList();
            Products = myDbContext.Products.ToList();
            Customers = myDbContext.Customers.ToList();
            OrderItems = myDbContext.OrderItems.ToList();

            Orders = myDbContext.CustomerOrders.ToList();

            OrderItems.ForEach(oi =>
            {
                oi.ProductName = Products.Find(x => x.Id == oi.ProductId).Name;
            });

            Orders.ForEach(item =>{
                item.OrderItems = OrderItems.FindAll(x=>x.OrderId == item.Id);
                item.CustomerDetails = Customers.Find(x=>x.Id == item.CustomerId);
                item.OrderStatus = OrderStatuses.Find(x => x.Id == item.OrderStatusId).Name;
            });
        }
    }
}
