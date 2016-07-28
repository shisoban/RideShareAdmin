using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace RideshareAdmin.DBAccess
{
    public class Class1
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public object _id { get; set; } //MongoDb uses this field as identity.

        public int ID { get; set; }

        //[Required]
        [BsonElement("firstname")]
        public string FirstName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        [BsonElement("lastname")]
        public string LastName { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
