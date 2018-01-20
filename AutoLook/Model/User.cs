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
    public class User
    {
        //[PrimaryKey]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Type { get; set; }

        public User()
        {
        }

        public static async Task<string> SaveUser(User user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_SaveUser);

                    var json = JsonConvert.SerializeObject(user);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    string rqSaveUser = JsonConvert.DeserializeObject<string>(ans);

                    return rqSaveUser;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> DeleteUser(User usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_DeleteUser);

                    var json = JsonConvert.SerializeObject(usuario);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    string rqDeleteUser = JsonConvert.DeserializeObject<string>(ans);

                    return rqDeleteUser;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> UpdateUser(User usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_UpdateUser);

                    var json = JsonConvert.SerializeObject(usuario);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    string rqUpdateUser = JsonConvert.DeserializeObject<string>(ans);

                    return rqUpdateUser;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> SaveFavorite(int UserID, int VehiclesID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(APIDictionary.API_SaveFavorite);

                    var json = JsonConvert.SerializeObject(new {
                        idVehicles = VehiclesID,
                        idUser = UserID
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    string rqSaveUser = JsonConvert.DeserializeObject<string>(ans);

                    return rqSaveUser;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<int>> GetFavorite(int UserID)
        {
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_GetFavorite);

                var json = JsonConvert.SerializeObject(new
                {
                    idUser = UserID
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                List<int> lstVehiculos = new List<int>();
                lstVehiculos = JsonConvert.DeserializeObject<List<int>>(ans);
                return lstVehiculos;
            }
        }
    }
}
