using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoLookBackend.Models;

namespace AutoLookBackend.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpPost]

        public void Login(string user, string pass)
        {
            LoginModel login = new LoginModel();

            login.Login(user, pass);
        }
    }
}
