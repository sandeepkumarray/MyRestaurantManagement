using Microsoft.EntityFrameworkCore;
using MyRestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CustomerOrderModel> CustomerOrders { get; set; }
        public DbSet<MenuModel> Menues { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<OrderStatusModel> OrderStatuses { get; set; }
        public DbSet<ProductCategoryModel> ProductCategories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantModel>().HasData(
                new RestaurantModel()
                {
                    Id = 1,
                    Name = "Danish Restaurant Pvt. Ltd.",
                    City = "Bengaluru",
                    ManagerName = "Rajiv Das",
                    PostalCode = "584732",
                    StreetNumber = 6,
                    Street = "Main Street"
                }
                );

            modelBuilder.Entity<ProductCategoryModel>().HasData(
                new ProductCategoryModel(1, "Chinese", 1),
                new ProductCategoryModel(2, "Bread", 1),
                new ProductCategoryModel(3, "Soups", 1),
                new ProductCategoryModel(4, "Veg Gravy", 1),
                new ProductCategoryModel(5, "Non - Veg Gravy", 1),
                new ProductCategoryModel(6, "Biriyani", 1),
                new ProductCategoryModel(7, "Rice", 1),
                new ProductCategoryModel(8, "Rolls", 1)
                );

            modelBuilder.Entity<MenuModel>().HasData(
                new MenuModel()
                {
                    Id = 1,
                    Name = "Main Menu",
                    RestaurantId = 1,
                    Active = 0
                }
                );

            modelBuilder.Entity<ProductModel>().HasData(
                    new ProductModel(1, 1, "Egg Noodles", 150, 1),
                    new ProductModel(2, 1, "Chicken Noodles", 200, 1),
                    new ProductModel(3, 1, "Veg Noodles", 120, 1),
                    new ProductModel(4, 1, "Roti", 20, 2),
                    new ProductModel(5, 1, "Naan", 40, 2),
                    new ProductModel(6, 1, "Butter Naan", 50, 2),
                    new ProductModel(7, 1, "Parota", 30, 2),
                    new ProductModel(8, 1, "Tomato Soup", 80, 3),
                    new ProductModel(9, 1, "Chicken Soup", 120, 3),
                    new ProductModel(10, 1, "Sweet Corn", 100, 3),
                    new ProductModel(11, 1, "Corn Masala", 140, 4),
                    new ProductModel(12, 1, "Paneer Butter Masala", 180, 4),
                    new ProductModel(13, 1, "Veg Curry", 150, 4),
                    new ProductModel(14, 1, "Butter Chicken", 200, 5),
                    new ProductModel(15, 1, "Chicken Masala", 200, 5),
                    new ProductModel(16, 1, "Mutton Masala", 250, 5),
                    new ProductModel(17, 1, "Egg Curry", 180, 5),
                    new ProductModel(18, 1, "Mutton Biriyani", 300, 6),
                    new ProductModel(19, 1, "Egg Biriyani", 180, 6),
                    new ProductModel(20, 1, "Chicken Biriyani", 250, 6),
                    new ProductModel(21, 1, "Prawns Biriyani", 200, 6),
                    new ProductModel(22, 1, "Veg Fried Rice", 150, 7),
                    new ProductModel(23, 1, "Egg Fried Rice", 180, 7),
                    new ProductModel(24, 1, "Mix Fried Rice", 250, 7),
                    new ProductModel(25, 1, "Chicken Roll", 80, 8),
                    new ProductModel(26, 1, "Egg Roll", 60, 8),
                    new ProductModel(27, 1, "Chicken Shawarma", 90, 8)
                );

            modelBuilder.Entity<OrderStatusModel>().HasData(
                    new OrderStatusModel(1, "Open"),
                    new OrderStatusModel(2, "Accepted"),
                    new OrderStatusModel(3, "Closed"),
                    new OrderStatusModel(4, "Paid"),
                    new OrderStatusModel(5, "Rejected"),
                    new OrderStatusModel(6, "Preparing"),
                    new OrderStatusModel(7, "Ready"),
                    new OrderStatusModel(8, "Out For Delivery"),
                    new OrderStatusModel(9, "Delivered"),
                    new OrderStatusModel(10, "In Cart")
                );

            modelBuilder.Entity<CustomerModel>().HasData(
                new CustomerModel()
                {
                    Id = 1,
                    Firstname = "Sanjeev",
                    Contact = 7799055675,
                    Address = "Flat No 21, DBC Appartment, 1st Main, Mahadevapura, 560145"
                },
                new CustomerModel()
                {
                    Id = 2,
                    Firstname = "Prashanth Jain",
                    Contact = 9645782213,
                    Address = "Flat No 036, Signature Endure, 6th Cross, Mahadevapura, 560145"
                }
                );

            modelBuilder.Entity<CustomerOrderModel>().HasData(
                new CustomerOrderModel()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderCreationDate = DateTime.Now,
                    TableNumber = 22,
                    Rate = 2000,
                    OrderStatusId = 1,
                }
                );

            modelBuilder.Entity<OrderItemModel>().HasData(
                new OrderItemModel(1, 1, 1, 1),
                new OrderItemModel(2, 1, 9, 1),
                new OrderItemModel(3, 1, 17, 1)
                );


            modelBuilder.Entity<CustomerOrderModel>().HasData(
                new CustomerOrderModel()
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderCreationDate = DateTime.Now,
                    TableNumber = 1,
                    Rate = 600,
                    OrderStatusId = 6,
                }
                );

            modelBuilder.Entity<OrderItemModel>().HasData(
                new OrderItemModel(4, 2, 11, 1),
                new OrderItemModel(5, 2, 3, 1),
                new OrderItemModel(6, 2, 25, 4)
                );
        }
    }
}
