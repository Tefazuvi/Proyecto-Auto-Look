using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using AutoLookBackend.Models;

namespace AutoLookBackend.Controllers
{
    public class CarController : Controller
    {
        
        [HttpPost]
        public string SaveCar(CarModel car)
        {
            string saved = car.SaveCar(car);
            return saved;
        }
    }
}
