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
    class Uercoordinates
    {
       // [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int __v { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNo { get; set; }
        public string userType { get; set; }
        
    }
}
