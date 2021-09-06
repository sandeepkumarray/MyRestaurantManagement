using MyRestaurantManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Models
{
    public class MenuViewModel
    {
        public List<MenuModel> Menues;
        public List<ProductModel> Products;
        public List<ProductCategoryModel> ProductCategories;
        private readonly MyDbContext myDbContext;
        public MenuModel Menu { get; set; }

        public Int64 RestaurantID;

        public MenuViewModel(MyDbContext _myDbContext) : this()
        {
            myDbContext = _myDbContext;
        }

        public MenuViewModel()
        {
            Menues = new List<MenuModel>();
            ProductCategories = new List<ProductCategoryModel>();
            Products = new List<ProductModel>();
        }
        public void LoadData()
        {
            Menu = myDbContext.Menues.Find(RestaurantID);
            ProductCategories = myDbContext.ProductCategories.ToList().FindAll(p=>p.RestaurantId== RestaurantID);
            Products = myDbContext.Products.ToList().FindAll(p=>p.MenuId == Menu.Id);

            Products.ForEach(item => {
                item.ProductCategory = ProductCategories.Find(x => x.Id == item.ProductCategoryId).Name;
            });
        }
    }
}
