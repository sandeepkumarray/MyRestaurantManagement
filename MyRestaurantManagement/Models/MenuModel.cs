using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantManagement.Models
{
	public class MenuModel
	{
		[JsonProperty("active")]
		[DisplayName("Active")]
		public Int64 Active { get; set; }

		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int64 Id { get; set; }

		[JsonProperty("name")]
		[DisplayName("Name")]
		public String Name { get; set; }

		[JsonProperty("restaurantid")]
		[DisplayName("Restaurantid")]
		public Int64 RestaurantId { get; set; }


		public MenuModel()
		{
		}

	}
}
