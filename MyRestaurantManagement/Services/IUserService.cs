using MyRestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(UserModel user, string password);
        void Update(UserModel user, string password = null);
        void Delete(int id);
    }
}
