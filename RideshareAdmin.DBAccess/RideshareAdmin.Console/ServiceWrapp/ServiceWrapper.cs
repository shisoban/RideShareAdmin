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

        //get all user from http://localhost:51074/api/user
        public List<UserModel> GetUsers()
        {
            string uri = baseUri + "/user";
            //string uri = baseUri;

            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.Accessservice(uri);
            DashboardStatics dasbordstatics = new DashboardStatics();
            UserModel usermodel;
            List<UserModel> usersList = new List<UserModel>();

            for (int i = 0; i < serviceh.Count; i++)
            {
                usermodel = new UserModel();

                usermodel.firstname = serviceh[i]["firstName"].ToString();
                usermodel.lastname = serviceh[i]["lastName"].ToString();
                usermodel.fullname = serviceh[i]["firstName"].ToString() + serviceh[i]["lastName"].ToString();
                usermodel.email = serviceh[i]["email"].ToString();
                usermodel.mobile = serviceh[i]["mobileNo"].ToString();
                //__V = v[i]["veh_description"].ToString();
                //email = v[i]["veh_location"].ToString();
                usersList.Add(usermodel);
            }
            return usersList;

        }

        //get distnation names for Location Vs RideCount graph using http://localhost:51074/api/rideHistory/RidesByLocation 
        public string GetLocationVsRideCountdName()
        {
            string uri = baseUri + "/rideHistory/RidesByLocation";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.Accessservice(uri);
            string[] destinationName = new string[serviceh.Count];

            for (int i = 0; i < serviceh.Count; i++)
            {
                destinationName[i] = "\"" + serviceh[i]["destinationName"].ToString() + "\"";
            }
            string destinationlist = "[" + string.Join(", ", destinationName) + "]";
            return destinationlist;

        }

        //get count for Location Vs RideCountdName graph using http://localhost:51074/api/rideHistory/RidesByLocation
        public string GetLocationVsRideCount_count()
        {
            string uri = baseUri + "/rideHistory/RidesByLocation";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.Accessservice(uri);
            string[] count = new string[serviceh.Count];
            for (int i = 0; i < serviceh.Count; i++)
            {
                count[i] = serviceh[i]["noOfUsersByLocation"].ToString();
            }
            string countList = "[" + string.Join(", ", count) + "]";
            return countList;

        }

        // get all rides list using http://localhost:51074/api/rideHistory
        public List<RideHistoriesEntity> GetRides()
        {
            string uri = baseUri + "/rideHistory";

            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.Accessservice(uri);
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

        }

        // get Current month ride count for dashboard using http://localhost:51074/api/rideHistory/RidesCountByMonth
        public string GetCurrentMonthRideCount()
        {
            string uri = baseUri + "/rideHistory/RidesCountByMonth";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var countAsObject = servicehelper.AccessserviceAsObject(uri);
            var countCurrentMonth = countAsObject["totalRides"].ToString();
            return countCurrentMonth;
        }

        // get Current month co2 reduction for dashboard using http://localhost:51074/api/TotalDistance/emission
        public string GetCurrentMonthCO2Reducation()
        {
            string uri = baseUri + "/TotalDistance/emission";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var co2ReductObject = servicehelper.AccessserviceAsObject(uri);
            var co2Reduction = co2ReductObject["emission"].ToString();
            return co2Reduction;
        }

        // get total co2 reduction for dashboard using http://localhost:51074/api/TotalDistance/emission
        public string GetTotalCO2Reducation()
        {
            string uri = baseUri + "/TotalDistance/Totalemission ";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var co2ReductObject = servicehelper.AccessserviceAsObject(uri);
            var co2Reduction = co2ReductObject["emission"].ToString();
            return co2Reduction;
        }

        //get Total distance covered for dashboard using http://localhost:51074/api/TotalDistance
        public string GetTotalDistanceCovered()
        {
            string uri = baseUri + "/TotalDistance";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var totalDistanceCoveredObject = servicehelper.AccessserviceAsObject(uri);
            var totalDistanceCovered = totalDistanceCoveredObject["totalDistance"].ToString();
            return totalDistanceCovered;
        }

        //get Total ride count for dashboard using http://localhost:51074/api/rideHistory/RidesCount
        public string GetTotalRidesCount()
        {
            string uri = baseUri + "/rideHistory/RidesCount";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var totalRidesObject = servicehelper.AccessserviceAsObject(uri);
            var totalRidesCount = totalRidesObject["ridesCount"].ToString();
            return totalRidesCount;
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
            string uri = baseUri + "/user/Countuser";
            ServiceHelperList servicehelper = new ServiceHelperList();
            var serviceh = servicehelper.Accessservice(uri);
            DashboardStatics dasbordstatics = new DashboardStatics();
            for (int i = 0; i < serviceh.Count; i++)
            {

                dasbordstatics.noofusers = serviceh[i]["userCount"].ToString();

            }
            return dasbordstatics;

        }


        //get rides between two date in dashboard using http://localhost:51074/api//RideListInDateRange
        public List<RideHistoriesEntity> GetRidesDatarange(string startdate, string enddate)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUri + "/RideListInDateRange");
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


