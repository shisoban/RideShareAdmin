using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RideshareAdmin.Console.ServiceWrapp
{
    public class ServiceHelperList
    {
        public JArray Accessservice(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var result = response.ToString();
                JArray v = JArray.Parse(response.Result);
                return v;
            }
        }

        public JObject AccessserviceAsObject(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var result = response.ToString();
                JObject v = JObject.Parse(response.Result);
                return v;
            }
        }

    }   
}