using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantManagement.Models
{
	public class ProductModel
	{
		[JsonProperty("active")]
		[DisplayName("Active")]
		public Int64 Active { get; set; }

		[JsonProperty("description")]
		[DisplayName("Description")]
		public String Description { get; set; }

		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int64 Id { get; set; }

		[JsonProperty("menuid")]
		[DisplayName("Menuid")]
		public Int64 MenuId { get; set; }

		[JsonProperty("name")]
		[DisplayName("Name")]
		public String Name { get; set; }

		[JsonProperty("percentdiscount")]
		[DisplayName("Percentdiscount")]
		public Int32 PercentDiscount { get; set; }

		[JsonProperty("photo")]
		[DisplayName("Photo")]
		public String Photo { get; set; }

		[JsonProperty("price")]
		[DisplayName("Price")]
		public Decimal Price { get; set; }

		[JsonProperty("productcategoryid")]
		[DisplayName("Productcategoryid")]
		public Int64 ProductCategoryId { get; set; }

		[NotMapped]
		public String ProductCategory { get; set; }
		public ProductModel()
		{
		}

		public ProductModel(Int64 id, Int64 menuId, String name, Decimal price, Int64 productCategoryId)
		{
			Id = id;
			MenuId = menuId;
			Name = name;
			Price = price;
			ProductCategoryId = productCategoryId;
		}
	}
}
