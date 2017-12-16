﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;

namespace AutoLook.Model
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int DoorsQuantity { get; set; }
        public int Capacity { get; set; }
        public string Motor { get; set; }
        public string Gas { get; set; }
        public bool ElectricWindows { get; set; }
        public bool CentralLock { get; set; }
        public bool HydraulicSteering { get; set; }
        public bool ElectricRearView { get; set; }
        public bool Alarm { get; set; }
        public bool AirConditioner { get; set; }
        public bool LuxuryHoops { get; set; }
        public ImageFile Cover { get; set; }

        public ObservableCollection<ImageFile> lstImagenes { get; set; }

        public CarModel()
        {
        }

        public static async Task<ObservableCollection<CarModel>> ObtenerVehiculos()
        {
            ObservableCollection<CarModel> lstVehiculos = new ObservableCollection<CarModel>();
            ObservableCollection<ImageFile> lstFotos = new ObservableCollection<ImageFile>();

            lstFotos.Add(new ImageFile { Path = "Jeep1.jpg" });
            lstFotos.Add(new ImageFile { Path = "Jeep2.jpg" });
            lstFotos.Add(new ImageFile { Path = "Jeep3.jpg" });

            lstVehiculos.Add(new CarModel { Id = 1, Brand = "Jeep", Model = "Wrangler", Colour = "Azul", Year = 2007, Type = "4x4", Price = 10000000, DoorsQuantity = 4, Capacity = 5, Motor = "3700 cc", Gas = "Gasolina", ElectricWindows = true, CentralLock = true, HydraulicSteering = true, ElectricRearView = true, Alarm = false, AirConditioner = true, LuxuryHoops = false, lstImagenes = lstFotos, Cover = lstFotos.First() });
            lstVehiculos.Add(new CarModel { Id = 2, Brand = "Jeep", Model = "Wrangler", Colour = "Azul", Year = 2007, Type = "4x4", Price = 10000000, DoorsQuantity = 4, Capacity = 5, Motor = "3700 cc", Gas = "Gasolina", ElectricWindows = true, CentralLock = true, HydraulicSteering = true, ElectricRearView = true, Alarm = false, AirConditioner = true, LuxuryHoops = false, lstImagenes = lstFotos, Cover = lstFotos.First() });
           
            return lstVehiculos;
        }
    }
}
