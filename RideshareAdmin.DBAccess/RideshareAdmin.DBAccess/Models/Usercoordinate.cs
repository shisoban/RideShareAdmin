using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideshareAdmin.DBAccess.Models
{
    public class Usercoordinate
    {
        // [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        //public string userName { get; set; }
        //public string email { get; set; }
        //public string driverUserName { get; set; }
        //public DateTime requestedTime { get; set; }
        //public string requestStatus { get; set; }
        //public string sourseName { get; set; }
        //public string destinationName { get; set; }
        //public float sourceLongitude { get; set; }
        //public float sourceLatitude { get; set; }
        //public float destinationLongitude { get; set; }
        //public float destinationLatitude { get; set; }
        //public int __v { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int __v { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNo { get; set; }
        public int userType { get; set; }
    }
}
