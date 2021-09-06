using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRestaurantManagement.Controllers;
using MyRestaurantManagement.Data;
using MyRestaurantManagement.Helpers;
using MyRestaurantManagement.Models;
using MyRestaurantManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyRestaurantManagement.Test
{
    public class AdminUnitTest
    {
        MyDbContext MyDbContext;
        IUserService userService;

        Dictionary<string, string> myConfiguration = new Dictionary<string, string>
                                                    {
                                                        {"AppSettings:Secret", "ASFJKFEIJFIAEFJAEIFJASKASJDAKSDJAKSDJASKDJAS"},
                                                        {"AppSettings:RestaurantID", "1"}
                                                    };
        IConfiguration configuration;
        public AdminUnitTest()
        {
            MyDbContext = MyDbContext ?? GetInMemoryDBContext();
            userService = new UserService(MyDbContext);

            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }

        protected MyDbContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            var options = builder.UseInMemoryDatabase("Orders").UseInternalServiceProvider(serviceProvider).Options;
            MyDbContext dbContext = new MyDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        [Theory]
        [InlineData("sandeep", "ray", "sandeep", "sandeep")]
        public void Register_User_ReturnsViewResult(string FirstName, string LastName, string Username, string Password)
        {
            AdminController adminController = new AdminController(userService, MyDbContext, configuration);
            RegisterModel registerModel = new RegisterModel(FirstName, LastName, Username, Password);
            var result = adminController.Register(registerModel);
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}
