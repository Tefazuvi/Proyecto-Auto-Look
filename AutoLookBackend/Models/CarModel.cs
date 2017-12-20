using System;
using System.Collections.Generic;

namespace AutoLookBackend.Models
{
    public class CarModel
    {

        #region Variables
        Conexion conexionM = new Conexion();
        #endregion

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

            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Brand", car.Brand));
                lstParams.Add(new ParameterSchema("Model", car.Brand));
                lstParams.Add(new ParameterSchema("Colour", car.Brand));
                lstParams.Add(new ParameterSchema("Years", car.Brand));
                lstParams.Add(new ParameterSchema("Miles", car.Brand));
                //Segui agregando los demas xq me dio pereza

                query = "Insert into Car (Brand,Model,Colour,Years,Miles) " +
                                    "values(@Brand,@Model,@Colour,@Years,@Miles)";

                return conexionM.setExecuteQuery(query, lstParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
