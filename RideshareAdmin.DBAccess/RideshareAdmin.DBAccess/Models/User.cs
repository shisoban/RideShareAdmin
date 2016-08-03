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
   public class User
    {

        
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonElement("_id")]
        public string _id { get; set; }
        //public ObjectId Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
        public string email  { get; set;}
    }
}
