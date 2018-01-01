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

        [HttpPost]
        public string SaveUser(LoginModel user)
        {
            string saved = user.SaveUser(user);
            return saved;
        }

        [HttpPost]
        public string DeleteUser(int id)
        {
            LoginModel user = new LoginModel();
            string deleted = user.DeleteUser(id);
            return deleted;
        }
    }
}
