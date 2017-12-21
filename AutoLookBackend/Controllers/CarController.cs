using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoLookBackend.Models;

namespace AutoLookBackend.Controllers
{
    public class CarController : ApiController
    {


        [System.Web.Http.HttpPost]
        public string SaveCar(CarModel car)
        {

            CarModel newcar = new CarModel();
            //newcar.SaveCar(car);
            return "";
        }
    }
}
