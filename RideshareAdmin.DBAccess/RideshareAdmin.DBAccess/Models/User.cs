using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RideshareAdmin.DBAccess.Models
{
   public class User
    {      
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
        public string email  { get; set;}
    }
}