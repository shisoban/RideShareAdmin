using BusinessEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RideshareAdmin.Console.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace RideshareAdmin.Console.ServiceWrapp
{
    public class ServiceWrapper
    {
        //readonly string baseUri = "http://localhost:51074/api/user";
        readonly string baseUri = "http://localhost:51074/api";

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
            string uri = baseUri + "/user";
            //string uri = baseUri;

            ServiceHelperList servicehelper = new ServiceHelperList();
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


        public List<RideHistoriesEntity> GetRides()
        {
            string uri = baseUri + "/rideHistory";
            //string uri = baseUri;

            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.accessservice(uri);
            // DashboardStatics dasbordstatics = new DashboardStatics();
            RideHistoriesEntity ridehistory;
            List<RideHistoriesEntity> ridelist = new List<RideHistoriesEntity>();

            for (int i = 0; i < serviceh.Count; i++)
            {
                ridehistory = new RideHistoriesEntity();

                ridehistory.userName = serviceh[i]["userName"].ToString();
                ridehistory.driverUserName = serviceh[i]["driverUserName"].ToString();
                ridehistory.sourseName = serviceh[i]["sourseName"].ToString();
                ridehistory.destinationName = serviceh[i]["destinationName"].ToString();
                ridehistory.requestedTime = DateTime.Parse(serviceh[i]["requestedTime"].ToString());
                ridehistory.time = serviceh[i]["time"].ToString();
                ridehistory.date = serviceh[i]["date"].ToString();
                ridehistory.distance = double.Parse(serviceh[i]["distance"].ToString());
                //__V = v[i]["veh_description"].ToString();
                //email = v[i]["veh_location"].ToString();
                ridelist.Add(ridehistory);
            }
            return ridelist;

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


        public string GetCurrentMonthRideCount()
        {
            string uri = baseUri + "/rideHistory/RidesCountByMonth";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var countAsObject = servicehelper.accessserviceAsObject(uri);
            var countCurrentMonth = countAsObject["totalRides"].ToString();
            return countCurrentMonth;
        }


        public string GetCurrentMonthCO2Reducation()
        {
            string uri = baseUri + "/TotalDistance/emission ";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var co2ReductObject = servicehelper.accessserviceAsObject(uri);
            var co2Reduction = co2ReductObject["emission"].ToString();
            return co2Reduction;
        }

        public string GetTotalCO2Reducation()
        {
            string uri = baseUri + "/TotalDistance/Totalemission ";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var co2ReductObject = servicehelper.accessserviceAsObject(uri);
            var co2Reduction = co2ReductObject["emission"].ToString();
            return co2Reduction;
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
           // http://localhost:51074/api/user/Countuser
            string uri = baseUri + "/user/Countuser";
            ServiceHelperList servicehelper = new ServiceHelperList();
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

        public  List<RideHistoriesEntity> GetRidesDatarange(string startdate, string enddate)
        {
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUri+"/RideListInDateRange");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    start_date = startdate,
                    end_date = enddate
                });

                streamWriter.Write(json);
            }
            string resultset;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resultset = result.ToString(); ;

            }

            JArray outputarray = JArray.Parse(resultset);
            //string uri2 = baseUri+ "/rideHistory";

            //ServiceHelperList servicehelper = new ServiceHelperList();
            //var serviceh = servicehelper.accessservice(uri2);
            // DashboardStatics dasbordstatics = new DashboardStatics();
            RideHistoriesEntity ridehistory;
            List<RideHistoriesEntity> ridelist = new List<RideHistoriesEntity>();

            for (int i = 0; i < outputarray.Count; i++)
            {
                ridehistory = new RideHistoriesEntity();

                ridehistory.userName = outputarray[i]["userName"].ToString();
                ridehistory.driverUserName = outputarray[i]["driverUserName"].ToString();
                ridehistory.sourseName = outputarray[i]["sourseName"].ToString();
                ridehistory.destinationName = outputarray[i]["destinationName"].ToString();
                ridehistory.requestedTime = DateTime.Parse(outputarray[i]["requestedTime"].ToString());
                ridehistory.time = outputarray[i]["time"].ToString();
                ridehistory.date = outputarray[i]["date"].ToString();
                ridehistory.distance = double.Parse(outputarray[i]["distance"].ToString());
                ridelist.Add(ridehistory);
            }
            return ridelist;

        }
    }




}

    
