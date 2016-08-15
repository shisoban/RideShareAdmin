using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RideshareAdmin.DBAccess.Models
{
    public class Ridehistories
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string userName { get; set; }
        public string driverUserName { get; set; }
        public DateTime requestedTime { get; set; }
        public int requestStatus { get; set; }
        public double distance { get; set; }  /* changed due to db change of column from string to double */
        public string sourseName { get; set; }
        public string destinationName { get; set; }
        public string sourceLongitude { get; set; }
        public string sourceLatitude { get; set; }
        public string destinationLongitude { get; set; }
        public string destinationLatitude { get; set; }
        public int __v { get; set; }

    }
}