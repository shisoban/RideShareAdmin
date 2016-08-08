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
        readonly string baseUrl = "http://localhost:51074/api/";

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

        public List<UserModel> GetUsers()
        {
            //   string uri = baseUri + id;
            string uri = baseUri;

            ServiceHelper servicehelper = new ServiceHelper();
            var serviceh = servicehelper.accessservice(uri);
            DashboardStatics dasbordstatics = new DashboardStatics();
            UserModel usermodel;
            List<UserModel> usersList = new List<UserModel>();

            for (int i = 0; i < serviceh.Count; i++)
            {
                usermodel = new UserModel();

                usermodel.firstname = serviceh[i]["firstName"].ToString();
                usermodel.lastname = serviceh[i]["lastName"].ToString();
                usermodel.userName = serviceh[i]["userName"].ToString();
                usermodel.email = serviceh[i]["email"].ToString();
                //__V = v[i]["veh_description"].ToString();
                //email = v[i]["veh_location"].ToString();
                usersList.Add(usermodel);
            }
            return usersList;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        Task<String> response = httpClient.GetStringAsync(uri);
        //        var result = response.ToString();
        //        JArray v = JArray.Parse(response.Result);
        //        List<UserModel> usersList = new List<UserModel>();
        //        //string firstname, lastname, userName, password, __V, email;
        //  //      UserModel usermodel;
        ////  public string password { get; set; }
        ////   public int __v { get; set; }
           

        //        for (int i = 0; i < v.Count; i++)
        //        {
        //            usermodel = new UserModel();

        //            usermodel.firstname = v[i]["firstName"].ToString();
        //            usermodel.lastname = v[i]["lastName"].ToString();
        //            usermodel.userName= v[i]["userName"].ToString();
        //            usermodel.email = v[i]["email"].ToString();
        //            //__V = v[i]["veh_description"].ToString();
        //            //email = v[i]["veh_location"].ToString();
        //            usersList.Add(usermodel);
        //        }
        //        return usersList;
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


        public DashboardStatics GetNumberstatics()
        {
            string uri = baseUri + "/Countuser";
            ServiceHelper servicehelper = new ServiceHelper();
            var serviceh = servicehelper.accessservice(uri);
            DashboardStatics dasbordstatics = new DashboardStatics();
            for (int i = 0; i < serviceh.Count; i++)
            {

                dasbordstatics.noofusers = serviceh[i]["userCount"].ToString();
                //__V = v[i]["veh_description"].ToString();
                //email = v[i]["veh_location"].ToString();

            }
            return dasbordstatics;

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    var result = response.ToString();
            //    JArray v = JArray.Parse(response.Result);
            //    //string firstname, lastname, userName, password, __V, email;
            //    DashboardStatics dasbordstatics = new DashboardStatics();
            //    //  public string password { get; set; }
            //    //   public int __v { get; set; }

            //for (int i = 0; i < v.Count; i++)
            //    {

            //        dasbordstatics.noofusers = v[i]["userCount"].ToString();
            //        //__V = v[i]["veh_description"].ToString();
            //        //email = v[i]["veh_location"].ToString();

            //    }
            //    return dasbordstatics;
            }
       
    }




}

    
