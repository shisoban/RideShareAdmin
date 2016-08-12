using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RideHistoriesEntity
    {
        // public string _id { get; set; }
        //public ObjectId Id { get; set; }
        public string userName { get; set; }
        public string driverUserName { get; set; }
        public DateTime requestedTime { get; set; }
        public string date { get { return requestedTime.ToShortDateString(); } set { } }
        public string time { get { return requestedTime.ToShortTimeString(); } set { } }
        public int requestStatus { get; set; }
        public string sourseName { get; set; }
        public string destinationName { get; set; }
        public double distance { get; set; }  /* changed due to db change of column from string to double */
        public string sourceLongitude { get; set; }
        public string sourceLatitude { get; set; }
        public string destinationLongitude { get; set; }
        public string destinationLatitude { get; set; }
        public int __v { get; set; }
    }

    public class RideCountByDriverEntity{
        public RideHistoriesEntity _id { get; set; }
        public int noOfRidesByDriver { get; set; }
        public string driverUserName { get { return _id.driverUserName; } set { } }
    }

    public class RideCountByDriveDetailEntity
    {
        public int noOfRidesByDriver { get; set; }
        public string driverUserName { get; set; }
    }


    // GetDistanceByMonth
    public class GetDistanceByMonthEntity
    {
        public GetDistanceByMonthEntity2 _id { get; set ; }
        public int totalMonthDistance { get; set; }
        public int month { get { return _id.month; } set { } }
    }
    public class GetDistanceByMonthEntity2
    {
        public RideHistoriesEntity _id { get; set; }
        public int totalMonthDistance { get; set; }
        public int month { get; set; }
    }
    public class GetDistanceByMonthDetailEntity
    {
        public int totalMonthDistance { get; set; }
        public int month { get; set; }
    }

}
