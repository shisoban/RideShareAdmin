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
    public class Repository<T> where T : class
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;

        // constructor to initialise database and table/collection  
        public Repository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);
        }

        // Get  method to retrieve user based on userName
        public IQueryable<T> Get(string i)
        {
            var query = Query.EQ("userName", i);
            MongoCursor<T> cursor = _collection.Find(query);
            return cursor.AsQueryable<T>();
        }

        //Get  method to retrieve all records
        public List<T> GetAll()
        {
            var userList = _collection.FindAll().ToList();
            var DeserializedUser = BsonSerializer.Deserialize<List<T>>(userList.ToJson());
            return DeserializedUser;
        }

    }
}
