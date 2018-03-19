using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAutomationProject.Models
{
	public class OrderDetailViewModel
	{
		public int OrderDetailNo { get; set; }
		public int OrderNo { get; set; }
		public int ItemNo { get; set; }
		public int Quantity { get; set; }
	}
}