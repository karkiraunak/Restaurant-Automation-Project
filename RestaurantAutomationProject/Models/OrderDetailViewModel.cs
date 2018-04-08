using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAutomationProject.Models
{
	public class OrderDetailViewModel
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public string PrepState { get; set; }
		public Nullable <int> PrepTime { get; set; }
		public string ItemName { get; set; }
		public int Price { get; set; }
	}
}