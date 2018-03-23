using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.SqlServer;
using System.Text;
using RestaurantAutomationProject.Models;


namespace RestaurantAutomationProject.Repository
{
    public class HomeRepository
    {

        public UserLogin GetUserName(int userId)
        {

            using (var db = new RestaurantAutomationEntities())
            {
                var result = from u in db.UserLogins
                             where u.UserId == userId
                             select u;

                 return result.FirstOrDefault();
            }
           
        }

        public UserLogin GetUserRoleAndId(string username, string password)
        {

            using (var db = new RestaurantAutomationEntities())
            {
                var result = from u in db.UserLogins
                             where u.Username == username && u.Password == password
                             select u;

                return result.FirstOrDefault();
            }

        }
       
    }
}