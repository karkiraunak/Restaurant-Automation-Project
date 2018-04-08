using RestaurantAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAutomationProject.Controllers
{
	public class OrderStatusController : Controller
	{
		// GET: OrderStatus
		public ActionResult Index()
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			var UserId = 0; // take from session later

			List<Order> ConfirmedOrderList = db.Orders.Where(o => o.OrderStatus == 1 && o.CustomerId == UserId).ToList(); // get the list of confirmed orders from the user

			int[] ConfirmedOrderId;   // array of confirmed orderId

			ConfirmedOrderId = ConfirmedOrderList.Select(x => x.OrderId).ToArray();  //populate array of confirmed orderid

			// find all orderdetails for confirmed orders

			List<OrderDetail> ConfirmedOrderDetailsList = db.OrderDetails.Where(o => ConfirmedOrderId.Contains(o.OrderId)).ToList();


			List<OrderDetailViewModel> confirmedOrderDetailVM = ConfirmedOrderDetailsList.Select(x => new OrderDetailViewModel
			{

				ItemName = x.Item.ItemName,
				PrepState = "cooking", // x.PrepState.State,
			    PrepTime = 1 // x.Item.ItemPrepTime

			}).ToList();

			return View(confirmedOrderDetailVM);
		}
	}
}

