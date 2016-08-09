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
        public JArray accessservice(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var result = response.ToString();
                JArray v = JArray.Parse(response.Result);
                return v;
            }
        }
    }
}