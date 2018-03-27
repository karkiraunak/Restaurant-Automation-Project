using RestaurantAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAutomationProject.Controllers
{
	public class OrderDetailController : Controller
	{
		// GET: OrderDetail
		public ActionResult Index()
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			var UserId = 0; // take from session later

			var OrderId = db.Orders.Where(o => o.CustomerId == UserId && o.OrderStatus == 0)   // order no ,   of unplaced order
									  .Select(o => o.OrderId)
									  .DefaultIfEmpty(0)
									  .Max();
	

			List<OrderDetail> orderDetailsList = db.OrderDetails.Where(o => o.OrderId == OrderId).ToList();



			List<OrderDetailViewModel> orderDetailsListVM = orderDetailsList.Select(x => new OrderDetailViewModel
			{
				
				ItemName = x.Item.ItemName,
				Price = x.Item.ItemPrice,
				Quantity = x.Quantity

			}).ToList();

			return View(orderDetailsListVM);
			
		}
	}
}