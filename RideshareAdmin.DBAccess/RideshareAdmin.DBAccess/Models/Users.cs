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
    class Users
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public object _id { get; set; } //MongoDb uses this field as identity.

        public int ID { get; set; }

        [Required]
        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [BsonElement("lastname")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
