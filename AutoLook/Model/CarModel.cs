using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using Realms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace AutoLook.Model
{
    public class CarModel
    {
        //[PrimaryKey]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string Transmision { get; set; }
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
        public bool AirConditioner  { get; set; }
        public bool LuxuryHoops { get; set; }

        public ImageFile Cover
        {
            get
            {
                return lstImagenes.FirstOrDefault();
            }
        }

        public ObservableCollection<ImageFile> lstImagenes { get; set; }

        public CarModel()
        {
        }


        public static async Task<string> SaveCar(CarModel car)
        {

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_SaveCar);

                    var json = JsonConvert.SerializeObject(car);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);

                    string ans = await response.Content.ReadAsStringAsync();

                    string rqSaveCar = JsonConvert.DeserializeObject<string>(ans);

                    return rqSaveCar;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<CarModel>> GetCars()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri(APIDictionary.API_GetCar);

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                List<CarModel> lstVehiculos = new List<CarModel>();
                lstVehiculos = JsonConvert.DeserializeObject<List<CarModel>>(ans);
                return lstVehiculos;
            }
        }
    }
}
