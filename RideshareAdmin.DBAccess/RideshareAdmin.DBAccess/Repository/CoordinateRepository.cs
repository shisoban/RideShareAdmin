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
    /** This a generic class */
    public class CoordinateRepository<T> where T : class
    {

        //private MongoDatabase database;
        //private string tableName;
        //private MongoCollection<T> collection;

        private MongoDatabase _database2;
        private string _tableName2;
        private MongoCollection<T> _collection2;

        /** constructor to initialise database and table/collection  */

        public CoordinateRepository(MongoDatabase db2, string tblName2)
        {
            _database2 = db2;
            _tableName2 = tblName2;
            _collection2 = _database2.GetCollection<T>(tblName2);
            // test();
        }


        /** Generic Get method to get record on the basis of id */
        public T Get(int i)
        {
            return _collection2.FindOneById(i);
        }


        ///** Get all records */
        //public IQueryable<T> GetAll()
        //{
        //    MongoCursor<T> cursor = _collection2.FindAll();
        //    return cursor.AsQueryable<T>();
        //}
        public List<Usercoordinate> GetAll()
        {
            var userCollection = _database2.GetCollection<BsonDocument>("usercoordinates");
            var coordinateList = userCollection.FindAll().ToList();
            var DeserializedCoordinate = BsonSerializer.Deserialize<List<Usercoordinate>>(coordinateList.ToJson());
            return DeserializedCoordinate;
        }

        //public List<Usercoordinate> GetAll()
        //{
        //    var userCollection = _database2.GetCollection<BsonDocument>("usercoordinates");
        //    var userList = userCollection.FindAll().ToList();
        //    var DeserializedUser = BsonSerializer.Deserialize<List<Usercoordinate>>(userList.ToJson());
        //    return DeserializedUser;
        //}


        /** Generic add method to insert enities to collection */
        public void Add(T entity)
        {
            _collection2.Insert(entity);
        }


        /** Generic delete method to delete record on the basis of id*/
        public void Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection2.Remove(query);
        }


        /** Generic update method to delete record on the basis of id*/
        public void Update(Expression<Func<T,int>> queryExpression, int id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection2.Update(query, Update<T>.Replace(entity));
        }



    }
}
