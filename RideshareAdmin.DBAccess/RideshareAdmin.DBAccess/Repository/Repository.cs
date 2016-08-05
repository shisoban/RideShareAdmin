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
           // test();
        }

        //public  void test()
        //{
        //    var collection = _database.GetCollection<BsonDocument>("users");
        //  //  var filter = Builders<BsonDocument>.Filter.Eq("grades.grade", "B");
        //    var query = new QueryDocument("userName", "vuser1");
        //    var result = collection.Find(query).ToList();//.AsQueryable<RideshareAdmin.DBAccess.Models.User>;
        //    var REsult = BsonSerializer.Deserialize<List<User>>(result.ToJson());

        //}

        /// <summary>
        /// Generic Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        //public T Get(string i)
        //{
        //    return _collection.FindOneById(i);

        //}

        /// <summary>
        /// Get  method to retrieve user based on userName
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IQueryable<T> Get(string i)
        {
            var query = Query.EQ("userName", i);
            MongoCursor<T> cursor = _collection.Find(query);
            return cursor.AsQueryable<T>();
        }

        /// <summary>
        /// Get all records 
        /// </summary>
        /// <returns></returns>
        //public IQueryable<T> GetAll()
        //{
        //    MongoCursor<T> cursor = _collection.FindAll();
        //    return cursor.AsQueryable<T>();
        //    //
        //}

        //public List<User> GetAll() //specific table 
        //{
        //    var userCollection = _database.GetCollection<BsonDocument>("users");
        //    var userList = userCollection.FindAll().ToList();
        //    var DeserializedUser = BsonSerializer.Deserialize<List<User>>(userList.ToJson());
        //    UserDetail ud = new UserDetail();
        //    for (int i = 0; i < DeserializedUser.Count; i++)
        //    {
        //            //ud.fname
        //    }
        //    return DeserializedUser;
        //}

            //generic 
        public List<T> GetAll()
        {
            //var userCollection = _database.GetCollection<BsonDocument>("users");
            var userList = _collection.FindAll().ToList();
            var DeserializedUser = BsonSerializer.Deserialize<List<T>>(userList.ToJson());
            return DeserializedUser;
        }
        /// <summary>
        /// Generic add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        public void Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        /// <summary>
        ///  Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(Expression<Func<T, int>> queryExpression, int id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

    }
}
