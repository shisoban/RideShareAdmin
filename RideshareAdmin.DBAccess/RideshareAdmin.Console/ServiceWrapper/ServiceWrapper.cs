using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RideshareAdmin.Console.ServiceWrapper
{
    public class ServiceWrapper : IServiceWrapper
    {
        public async Task<string> LoginUser(string username, string password)
        {
            using (var client = new HttpClient())
            {

                var result = await client.GetAsync("http://localhost:49604/Applicaion_Service/RideshareService.svc/LoginUser/" + username + "/" + password + "/");
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}