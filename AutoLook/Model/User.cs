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

namespace AutoLook.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
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
                    var uri = new Uri("http://6c7c0456.ngrok.io/Login/SaveUser");

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
                    var uri = new Uri("http://6c7c0456.ngrok.io/Login/DeleteUser");

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
                    var uri = new Uri("http://6c7c0456.ngrok.io/Login/UpdateUser");

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
    }
}
