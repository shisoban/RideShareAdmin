using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RideshareAdmin.DBAccess.Models
{
    public class Usercoordinate
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
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