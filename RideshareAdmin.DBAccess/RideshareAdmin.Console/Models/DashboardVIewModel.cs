using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideshareAdmin.Console.Models
{
    public class DashboardVIewModel
    {
        public string Noofkillometer { get; set; }
        public string Noofusers { get; set; }
        public string TotalRidesCount { get; set; }
        public string CountCurrentMonthRide { get; set; }
        public string CO2Reductiontotal { get; set; }
        public string CountCurrentMonthRidePercentage { get
            {
                double monthRidePercentage = double.Parse(CountCurrentMonthRide) / 200 * 100;
                return monthRidePercentage.ToString();
            } set{ } }
        public string CurrentMonthCO2Reduction { get; set; }
        public string CurrentMonthCO2ReductionPercentage { get { double Co2percentage = double.Parse(CurrentMonthCO2Reduction)/400*100;
                return Co2percentage.ToString();
            } set { } }
        public string destinationName { get; set; }
        public string countByDestination { get; set; }
    }
}