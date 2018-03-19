using RestaurantAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAutomationProject.Controllers
{
	public class TestController : Controller
	{
		// GET: Test
		public ActionResult Index()
		{
			List<Employee> employeelist = new List<Employee>();

			return View(employeelist);
		}
	}
}