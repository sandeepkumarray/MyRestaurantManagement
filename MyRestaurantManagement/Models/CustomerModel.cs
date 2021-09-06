using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurantManagement.Models
{
	public class CustomerModel
	{
		[MaxLength(10, ErrorMessage = "Contact number should be 10 characters long")]
		[Required]
		[JsonProperty("contact")]
		[DisplayName("Contact")]
		public long Contact { get; set; }

		[Required]
		[JsonProperty("firstname")]
		[DisplayName("Firstname")]
		public String Firstname { get; set; }

		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int64 Id { get; set; }

		[Required]
		[MaxLength(250, ErrorMessage = "Address Cannot be more than 50 characters")]
		[JsonProperty("address")]
		[DisplayName("Address")]
		public String Address { get; set; }

		[NotMapped]
		[Required]
		[DisplayName("Name on Card")]
		public string NameOnCard { get; set; }

		[NotMapped]
		[Required]
		[DisplayName("Card Number")]
		[MaxLength(19, ErrorMessage = "Must be between 12 and 19 digits")]
		[MinLength(12, ErrorMessage = "Must be between 12 and 19 digits")]
		[Range(100000000000, 9999999999999999999, ErrorMessage = "Must be between 12 and 19 digits")]
		public long CardNumber { get; set; }
		
		[NotMapped]
		[Required]
		[DisplayName("Expiry")]
		[Range(1, 12, ErrorMessage = "Invalid month")]
		public int ExpiryMonth { get; set; }

		[NotMapped]
		[Required]
		[DisplayName("Expiry")]
		public int ExpiryYear { get; set; }

		[NotMapped]
		[Required]
		[DisplayName("CVV")]
		[MaxLength(4, ErrorMessage = "CVV should be maximum of 4 characters.")]
		[MinLength(3, ErrorMessage = "CVV should be minimum of 3 characters.")]
		public string CVV { get; set; }

		public CustomerModel()
		{
		}

		public CustomerModel(Int64 id, String firstname, long contact)
		{
			Id = id;
			Firstname = firstname;
			Contact = contact;
		}

	}
}
