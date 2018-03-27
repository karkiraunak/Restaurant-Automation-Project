using RestaurantAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAutomationProject.Controllers
{
	public class MenuController : Controller
	{
		

		// GET: Menu
		public ActionResult Index()
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			List<Item> itemList = db.Items.ToList();

			List<MenuViewModel> itemListVM = itemList.Select(x => new MenuViewModel
			{

				ItemId = x.ItemId,

				ItemName = x.ItemName,
				ItemPrice = x.ItemPrice,
				ItemPhotoUrl = x.ItemPhotoUrl,
				CategoryName = x.Category.CategoryName
				
			}).ToList();

			return View(itemListVM);
		}

		public JsonResult PostOrder(OrderDetailViewModel OrderDetailJSON)
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			Order order = new Order();
			OrderDetail odetail = new OrderDetail();
			// before creating OrderDetail , Order has to be created . if an Order is already created but not placed, add items in that order no for same custommer 
			// if the order has not created , create order for that customer

			var UserId = 0;   // for now 0 , but get from session later
			var OrderId = db.Orders.Where(o => o.CustomerId == UserId && o.OrderStatus == 0)
								   .Select(o => o.OrderId)
								   .DefaultIfEmpty(0)
								   .Max();
			if (OrderId == 0) // create order if customer is adding first item in order
			{

				var MaxOrderId = db.Orders.Select(o => o.OrderId).DefaultIfEmpty(0).Max();
				order.OrderId = MaxOrderId + 1;
				order.CustomerId = UserId;
				order.OrderDate = DateTime.Today;
				order.OrderStatus = 0;    //orderstaus = 0 , incomplete order , 1 : full order 2 payment received order

				odetail.OrderDetailId = db.OrderDetails.Select(o => o.OrderDetailId).DefaultIfEmpty(0).Max() + 1;
				odetail.OrderId = MaxOrderId + 1;
				odetail.ItemId = OrderDetailJSON.ItemId;
				odetail.Quantity = OrderDetailJSON.Quantity;

				db.Orders.Add(order);
				db.OrderDetails.Add(odetail);
				
				db.SaveChanges();

			}
			else  // create orderdetails if order is created and customer is adding item on it
			{
				//if customer adds the same item more than one time overwrite the quantity with new quantity
				odetail.OrderId = OrderId;


				var orderDetailId = db.OrderDetails.Where(o => o.OrderId == OrderId && o.ItemId == OrderDetailJSON.ItemId)   //checking if orderdetail exist already for that item
							          .Select(o => o.OrderDetailId)
							          .DefaultIfEmpty(0)
							          .Max();


				if (orderDetailId == 0) // if orderdetail doesnot exist already for that item , create orderdetail
				{
					odetail.OrderDetailId = db.OrderDetails.Select(o => o.OrderDetailId).DefaultIfEmpty(0).Max() + 1;
					odetail.ItemId = OrderDetailJSON.ItemId;
					odetail.Quantity = OrderDetailJSON.Quantity;
					db.OrderDetails.Add(odetail);

				}
				else  //
				{
					odetail = db.OrderDetails.FirstOrDefault(o => o.OrderDetailId == orderDetailId);
					odetail.Quantity = OrderDetailJSON.Quantity;
				}
				

				db.SaveChanges();



			}


			OrderDetailViewModel OrderDetailVM = new OrderDetailViewModel();
			OrderDetailVM.OrderId = 1;
			OrderDetailVM.OrderDetailId = 1;
			OrderDetailVM.OrderId = 1;
			OrderDetailVM.Quantity = OrderDetailJSON.Quantity;
			Console.WriteLine("hello" + OrderDetailVM.Quantity);

			return Json ("OrderDetailJSON.Quantity");
		}
	}
}




