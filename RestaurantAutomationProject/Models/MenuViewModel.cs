using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAutomationProject.Models
{
	public class MenuViewModel
	{
		
		public int Id { get; set; }
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public int ItemPrice { get; set; }
		public string ItemPhotoUrl { get; set; }
		public string ItemType { get; set; }

	}
}