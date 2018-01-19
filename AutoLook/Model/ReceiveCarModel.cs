using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace AutoLook.Model
{
    public class ReceiveCarModel: User
    {
        //[PrimaryKey]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public string Damage { get; set; }

        public ImageFile Cover
        {
            get
            {
                return lstImagenes.FirstOrDefault();
            }
            set
            {

            }
        }

        public ObservableCollection<ImageFile> lstImagenes { get; set; }

        public ReceiveCarModel()
        {
        }

        public static async Task<ObservableCollection<ReceiveCarModel>> ObtenerVehiculos()
        {
            ObservableCollection<ReceiveCarModel> lstVehiculos = new ObservableCollection<ReceiveCarModel>();

            List<ReceiveCarModel> listaVehiculos = new List<ReceiveCarModel>();
            ObservableCollection<ImageFile> lstFotos = new ObservableCollection<ImageFile>();

            lstFotos.Add(new ImageFile { Path = "Jeep1.jpg", Image = File.ReadAllBytes("Jeep1.jpg")});
            lstFotos.Add(new ImageFile { Path = "Jeep2.jpg", Image = File.ReadAllBytes("Jeep2.jpg")});
            lstFotos.Add(new ImageFile { Path = "Jeep3.jpg", Image = File.ReadAllBytes("Jeep3.jpg")});

            lstVehiculos.Add(new ReceiveCarModel { Id = 1, Brand = "Jeep", Model = "Wrangler", Year = 2012, Miles=3000, Damage = "Llantas desgastadas", lstImagenes = lstFotos });
            lstVehiculos.Add(new ReceiveCarModel { Id = 2, Brand = "Jeep", Model = "Wrangler", Year = 2007, Miles=2000, Damage = "Rotulas, faja.", lstImagenes = lstFotos });

            return lstVehiculos;
        }

        public static async Task<string> SaveCar(ReceiveCarModel receivecar, int id)
        {

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_ReceiveSaveCar);

                    var json = JsonConvert.SerializeObject(new
                    {
                        car = receivecar,
                        userid = id
                    });

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
        public static async Task<ObservableCollection<ReceiveCarModel>> GetCars()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri(APIDictionary.API_ReceiveGetCar);

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                ObservableCollection<ReceiveCarModel> lstVehiculos = new ObservableCollection<ReceiveCarModel>();
                lstVehiculos = JsonConvert.DeserializeObject<ObservableCollection<ReceiveCarModel>>(ans);
                return lstVehiculos;
            }
        }
    }
}
