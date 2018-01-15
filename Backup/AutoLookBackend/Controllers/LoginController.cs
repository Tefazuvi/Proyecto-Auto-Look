using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using AutoLookBackend.Models;

namespace AutoLookBackend.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpPost]
        public string Authenticate(string User, string Pass)
        {
            LoginModel login = new LoginModel();
            string user = login.Login(User, Pass);
            return user;
        }

        public string SaveUser(LoginModel user)
        {
            string saved = user.SaveUser(user);
            return saved;
        }

        public string DeleteUser(LoginModel user)
        {
            string deleted = user.DeleteUser(user);
            return deleted;
        }

        public string UpdateUser(LoginModel user)
        {
            string updated = user.UpdateUser(user);
            return updated;
        }
    }
}
