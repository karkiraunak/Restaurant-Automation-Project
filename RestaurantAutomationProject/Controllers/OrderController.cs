using RestaurantAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAutomationProject.Controllers
{
	public class OrderController : Controller
	{
		// GET: Order
		

		public ActionResult PostOrder()  //update the order status of the order once customer quick confirms / confirms order
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			Order order = new Order();
			var UserId = 0;  // find from session later

			var OrderId = db.Orders.Where(o => o.CustomerId == UserId && o.OrderStatus == 0)
								   .Select(o => o.OrderId)
								   .DefaultIfEmpty(0)
								   .Max();

			order = db.Orders.FirstOrDefault(o => o.OrderId == OrderId);  // find the unconfirmoed order of the customer and confirm it
			order.OrderStatus = 1;  // change status to confirmed
			db.SaveChanges();
			return Json(Url.Action("Index", "OrderStatus"));

		}

	}
}
