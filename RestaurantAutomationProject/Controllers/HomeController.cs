using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using RestaurantAutomationProject.Models;
using System.Data.Entity;
using RestaurantAutomationProject.Repository;

namespace RestaurantAutomationProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is to check validity
            {
                var repo = new Repository.HomeRepository();

                var username = login.Username;
                var password = login.Password;
                          
                var userRole = repo.GetUserRoleAndId(username, password);

                if (userRole != null)
                {
                    if (userRole.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Menu", new { userId = userRole.UserId });
                    }
                    else if (userRole.RoleId == 1)
                    {
                        return RedirectToAction("UserProfile", new { userId = userRole.UserId });
                    }

                    else
                    {
                        return RedirectToAction("Index", "Menu", new { userId = userRole.UserId });
                    }
                }
            }
            return View(login);
        }

        public ActionResult AfterLogin(string username)
        {           

            if (username != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
                
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                using (RestaurantDBEntities db = new RestaurantDBEntities())
                {
                    var repo = new HomeRepository();

                    var checkUser = repo.GetUserRoleAndId(login.Username, login.Password);

                    if (checkUser == null)
                    {
                        //you should check duplicate registration here 
                        // dc.Roles.Add(U);
                        // db.Entry()
                        UserLogin ul = new UserLogin();
                        User u = new User();

                        ul.Username = login.Username;
                        ul.Password = login.Password;
                        ul.RoleId = 2;
                        u.RoleId = 2;
                        u.FirstName = login.FirstName;
                        u.LastName = login.LastName;
                        u.Email = login.Username;
                        u.UserId = login.UserID;

                        db.Entry(ul).State = EntityState.Added;
                        db.Entry(u).State = EntityState.Added;
                       
                        db.SaveChanges();
                        ModelState.Clear();
                        //  login = null;
                        ViewBag.Message = "Successfully Registration Done";
                    }

                    else
                    {
                        ViewBag.Message = "This email already exists in the system.";
                    }
                }
            }
            return RedirectToAction("Login", new { id = login.UserID });
        }

        public ActionResult UserProfile(int userId)
        {
            var repo = new HomeRepository();

            var userDetail = repo.GetUserName(userId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                using (RestaurantDBEntities db = new RestaurantDBEntities())
                {

                    //you should check duplicate registration here 
                    // dc.Roles.Add(U);
                    // db.Entry()
                    UserLogin ul = new UserLogin();
                    User u = new User();

                    ul.Username = login.Username;
                    // ul.Password = login.Password;
                    ul.RoleId = 2;
                    u.FirstName = login.FirstName;
                    u.LastName = login.LastName;
                    u.Email = login.Email;
                    u.Address1 = login.Address1;
                    u.Address2 = login.Address2;
                    u.City = login.City;
                    u.State = login.State;
                    u.Zip = login.Zip;
                    u.UserId = ul.UserId;


                    db.Entry(ul).State = EntityState.Modified;
                    db.Entry(u).State = EntityState.Modified;

                    db.SaveChanges();
                    ModelState.Clear();
                    //  login = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(login);
        }

    }
}