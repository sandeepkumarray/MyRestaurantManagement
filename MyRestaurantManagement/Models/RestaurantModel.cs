using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantManagement.Models
{
	public class RestaurantModel
	{
		[JsonProperty("city")]
		[DisplayName("City")]
		public String City { get; set; }

		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int64 Id { get; set; }

		[JsonProperty("managername")]
		[DisplayName("Managername")]
		public String ManagerName { get; set; }

		[JsonProperty("name")]
		[DisplayName("Name")]
		public String Name { get; set; }

		[JsonProperty("photo")]
		[DisplayName("Photo")]
		public String Photo { get; set; }

		[JsonProperty("postalcode")]
		[DisplayName("Postalcode")]
		public String PostalCode { get; set; }

		[JsonProperty("street")]
		[DisplayName("Street")]
		public String Street { get; set; }

		[JsonProperty("streetnumber")]
		[DisplayName("Streetnumber")]
		public Int32 StreetNumber { get; set; }


		public RestaurantModel()
		{
		}

	}
}
