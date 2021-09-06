using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantManagement.Models
{
	public class OrderStatusModel
	{
		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int32 Id { get; set; }

		[JsonProperty("name")]
		[DisplayName("Name")]
		public String Name { get; set; }


		public OrderStatusModel()
		{
		}

		public OrderStatusModel(Int32 id, String name)
		{
			Id = id;
			Name = name;
		}
	}
}
