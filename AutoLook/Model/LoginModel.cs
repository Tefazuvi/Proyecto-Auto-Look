using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AutoLook.Model
{
    public class LoginModel
    {
        public LoginModel()
        {
        }

        public static async Task<User> Authenticate(string UserName, string Password)
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri(APIDictionary.API_Authenticate);

                var json = JsonConvert.SerializeObject(new
                {
                    User = UserName,
                    Pass = Password
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                User loginUser = JsonConvert.DeserializeObject<User>(ans);
                return loginUser;
            }
        }
    }
}
