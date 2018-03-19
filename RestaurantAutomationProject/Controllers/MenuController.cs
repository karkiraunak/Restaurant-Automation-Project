﻿using RestaurantAutomationProject.Models;
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
				ItemNo = x.ItemNo,
				ItemName = x.ItemName,
				ItemPrice = x.ItemPrice,
				ItemPhotoUrl = x.ItemPhotoUrl,
				ItemType = x.ItemType.TypeName
				
			}).ToList();

			return View(itemListVM);
		}

		public JsonResult PostOrder(OrderDetailViewModel OrderDetailJSON)
		{
			RestaurantDBEntities db = new RestaurantDBEntities();

			OrderViewModel OrderVM = new OrderViewModel();



			OrderDetailViewModel OrderDetailVM = new OrderDetailViewModel();
			OrderDetailVM.ItemNo = 1;
			OrderDetailVM.OrderDetailNo = 1;
			OrderDetailVM.OrderNo = 1;
			OrderDetailVM.Quantity = OrderDetailJSON.Quantity;
			Console.WriteLine("hello" + OrderDetailVM.Quantity);
			return Json ("OrderDetailJSON.Quantity");
		}
	}
}