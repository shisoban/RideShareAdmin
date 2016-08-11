using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using RideshareAdmin.DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RideshareAdmin.DBAccess.Repository
{
    public class UserRepository<User> where User : class
    {
        protected MongoDatabase _database;
        protected string _tableName;
        protected MongoCollection<User> _collection;


        public UserRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<User>(tblName);
        }

        // Get  method to retrieve user based on userName
        public IQueryable<User> Get(string i)
        {
            var query = Query.EQ("userName", i);
            MongoCursor<User> cursor = _collection.Find(query);
            return cursor.AsQueryable<User>();
        }

        //Get  method to retrieve all records
        public List<User> GetAll()
        {
            var userList = _collection.FindAll().ToList();
            var DeserializedUser = BsonSerializer.Deserialize<List<User>>(userList.ToJson());
            return DeserializedUser;
        }
    }
    }
