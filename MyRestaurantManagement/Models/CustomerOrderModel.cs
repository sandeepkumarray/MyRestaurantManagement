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
	public class CustomerOrderModel
	{
		[JsonProperty("comments")]
		[DisplayName("Comments")]
		public String Comments { get; set; }

		[JsonProperty("customerid")]
		[DisplayName("Customerid")]
		public Int64 CustomerId { get; set; }

		[JsonProperty("paymentid")]
		[DisplayName("PaymentID")]
		public string PaymentID { get; set; }

		[JsonProperty("id")]
		[DisplayName("Id")]
		public Int64 Id { get; set; }

		[JsonProperty("ordercreationdate")]
		[DisplayName("Ordercreationdate")]
		public DateTime OrderCreationDate { get; set; }

		[JsonProperty("orderfinisheddate")]
		[DisplayName("Orderfinisheddate")]
		public DateTime OrderFinishedDate { get; set; }

		[JsonProperty("orderstatusid")]
		[DisplayName("Orderstatusid")]
		public Int32 OrderStatusId { get; set; }

		[JsonProperty("rate")]
		[DisplayName("Rate")]
		public decimal Rate { get; set; }

		[JsonProperty("ratedetails")]
		[DisplayName("Ratedetails")]
		public String RateDetails { get; set; }

		[JsonProperty("tablenumber")]
		[DisplayName("Tablenumber")]
		public Int32 TableNumber { get; set; }

		[NotMapped]
		public String OrderStatus { get; set; }

		[NotMapped]
		public List<OrderItemModel> OrderItems { get; set; }

		[NotMapped]
		[Required]
		public CustomerModel CustomerDetails { get; set; }


		public CustomerOrderModel()
		{
		}

	}
}
