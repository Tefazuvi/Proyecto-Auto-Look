using System;
using System.Collections.Generic;

namespace AutoLookBackend.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
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


        public CarModel()
        {
        }

        public static string SaveCar(CarModel car)
        {
            Conexion conexionM = new Conexion();

            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Brand", car.Brand));
                lstParams.Add(new ParameterSchema("Model", car.Model));
                lstParams.Add(new ParameterSchema("Colour", car.Colour));
                lstParams.Add(new ParameterSchema("Year", car.Year));
                lstParams.Add(new ParameterSchema("Miles", car.Miles));
                lstParams.Add(new ParameterSchema("Type", car.Type));
                lstParams.Add(new ParameterSchema("Price", car.Price));
                lstParams.Add(new ParameterSchema("DoorsQuantity", car.DoorsQuantity));
                lstParams.Add(new ParameterSchema("Capacity", car.Capacity));
                lstParams.Add(new ParameterSchema("Motor", car.Motor));
                lstParams.Add(new ParameterSchema("Gas", car.Gas));
                lstParams.Add(new ParameterSchema("ElectricWindows", car.ElectricWindows));
                lstParams.Add(new ParameterSchema("CentralLock", car.CentralLock));
                lstParams.Add(new ParameterSchema("HydraulicSteering", car.HydraulicSteering));
                lstParams.Add(new ParameterSchema("ElectricRearView", car.ElectricRearView));
                lstParams.Add(new ParameterSchema("Alarm", car.Alarm));
                lstParams.Add(new ParameterSchema("AirConditioner", car.AirConditioner));
                lstParams.Add(new ParameterSchema("LuxuryHoops", car.LuxuryHoops));

                query = "Insert into Car (Brand,Model,Colour,Years,Miles,Type,Price,DoorsQuantity,Capacity,Motor,Gas,ElectricWindows,CentralLock,HydraulicSteering,ElectricRearview,Alarm,AirConditioner,LuxuryHoops) " +
                    "values(@Brand,@Model,@Colour,@Year,@Miles,@Type,@Price,@DoorsQuantity,@Capacity,@Motor,@Gas,@ElectricWindows,@CentralLock,@HydraulicSteering,@ElectricRearview,@Alarm,@AirConditioner,@LuxuryHoops)";

                return conexionM.setExecuteQuery(query, lstParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
