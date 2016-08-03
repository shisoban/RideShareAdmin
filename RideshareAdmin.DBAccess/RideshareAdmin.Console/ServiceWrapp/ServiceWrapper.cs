using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RideshareAdmin.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace RideshareAdmin.Console.ServiceWrapp
{
    public class ServiceWrapper
    {
        readonly string baseUri = "http://localhost:51074/api/user";

        public UserModel GetCars()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var account = JsonConvert.DeserializeObject<UserModel>(response.Result);
                return JsonConvert.DeserializeObjectAsync<UserModel>(response.Result).Result;
            }
        }

        public UserModel GetCarById()
        {
            //   string uri = baseUri + id;
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var result = response.ToString();
                JArray v = JArray.Parse(response.Result);
                //string firstname, lastname, userName, password, __V, email;
                for (int i = 0; i < v.Count; i++)
                {
                    
                    //firstname = v[i]["dri_lname"].ToString();
                    //lastname = v[i]["dri_phoneno"].ToString();
                    //userName = v[i]["veh_Latitude"].ToString();
                    //password = v[i]["veh_Longitude"].ToString();
                    //__V = v[i]["veh_description"].ToString();
                    //email = v[i]["veh_location"].ToString();
                }
                return null;
            }
        }
        public static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51074/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("user");
                if (response.IsSuccessStatusCode)
                {
                    UserModel users = await response.Content.ReadAsAsync<UserModel>();
                    string b = users.ToString();
                  //  Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }

               
            }
        }
    }




}

    
