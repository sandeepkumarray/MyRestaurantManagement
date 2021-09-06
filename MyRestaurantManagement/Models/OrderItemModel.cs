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
	public class OrderItemModel
	{
		[JsonProperty("id")]
		[DisplayName("Id")]
		[Key]
		public Int64 Id { get; set; }

		[JsonProperty("orderid")]
		[DisplayName("Orderid")]
		public Int64 OrderId { get; set; }

		[JsonProperty("productid")]
		[DisplayName("Productid")]
		public Int64 ProductId { get; set; }

		[JsonProperty("quantity")]
		[DisplayName("Quantity")]
		public Int32 Quantity { get; set; }

		[NotMapped]
		public String ProductName { get; set; }

		[NotMapped]
		public decimal TotalAmount { get; set; }

		public OrderItemModel()
		{
		}

		public OrderItemModel(Int64 orderId, Int64 productId, Int32 quantity)
		{
			OrderId = orderId;
			ProductId = productId;
			Quantity = quantity;
		}

		public OrderItemModel(Int64 id, Int64 orderId, Int64 productId, Int32 quantity) : this(orderId, productId, quantity)
		{
			Id = id;
			OrderId = orderId;
			ProductId = productId;
			Quantity = quantity;
		}
	}
}
