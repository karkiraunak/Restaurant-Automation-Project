using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAutomationProject.Models
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public System.DateTime OrderDate { get; set; }
		public int Subtotal { get; set; }
		public int Tax { get; set; }
		public int TotalAmount { get; set; }
		public int CustomerId { get; set; }
	
	}
}