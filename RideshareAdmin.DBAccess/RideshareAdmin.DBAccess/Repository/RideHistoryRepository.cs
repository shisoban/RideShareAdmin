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
     public class RideHistoryRepository<RideHistory> where RideHistory : class
    {
        protected MongoDatabase _database;
        protected string _tableName;
        protected MongoCollection<RideHistory> _collection;


        public RideHistoryRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<RideHistory>(tblName);
        }

        // Get  method to retrieve user based on userName
        public IQueryable<RideHistory> Get(string i)
        {
            var query = Query.EQ("userName", i);
            MongoCursor<RideHistory> cursor = _collection.Find(query);
            return cursor.AsQueryable<RideHistory>();
        }

        //Get  method to retrieve all records
        public List<RideHistory> GetAll()
        {
            var userList = _collection.FindAll().ToList();
            var DeserializedUser = BsonSerializer.Deserialize<List<RideHistory>>(userList.ToJson());
            return DeserializedUser;
        }


        public List<BsonDocument> GetAllByLocation()
        {

            var group = new BsonDocument
                          {
                              { "$group",
                                  new BsonDocument
                                      {
                                          { "_id", new BsonDocument
                                                       {
                                                           {
                                                               "destinationName","$destinationName"
                                                           }
                                                       }
                                          },
                                          {
                                              "noOfUsersByLocation", new BsonDocument
                                                           {
                                                               {
                                                                   "$sum", 1
                                                               }
                                                           }
                                          }
                                      }

                            }
                          };
//            var sort = new BsonDocument {
//    {
//        "$sort",
//        new BsonDocument {
//            { "totalView", -1 }
//        }
//    }
//};
            //    $sort: { "cars_owned" : -1}
            //}, {$limit : 10}
            var pipeline = new[] { group };
            var args = new AggregateArgs { Pipeline = pipeline };
            var result = _collection.Aggregate(args).ToList();
            return result;

           
           
        }

    }
}
