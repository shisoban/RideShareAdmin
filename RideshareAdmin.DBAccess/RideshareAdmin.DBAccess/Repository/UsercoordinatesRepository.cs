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
    public class UsercoordinatesRepository<Usercoordinate> where Usercoordinate : class
    {
        protected MongoDatabase _database;
        protected string _tableName;
        protected MongoCollection<Usercoordinate> _collection;


        public UsercoordinatesRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<Usercoordinate>(tblName);
        }

        // Get  method to retrieve user based on userName
        public IQueryable<Usercoordinate> Get(string i)
        {
            var query = Query.EQ("userName", i);
            MongoCursor<Usercoordinate> cursor = _collection.Find(query);
            return cursor.AsQueryable<Usercoordinate>();
        }

        //Get  method to retrieve all records
        public List<Usercoordinate> GetAll()
        {
            var userList = _collection.FindAll().ToList();
            var DeserializedUser = BsonSerializer.Deserialize<List<Usercoordinate>>(userList.ToJson());
            return DeserializedUser;
        }
    }
}