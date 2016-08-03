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
    class Repository <T> where T : class
    {

        private MongoDatabase database;
        private string tableName;
        private MongoCollection<T> collection;

        /** constructor to initialise database and table/collection  */

        public Repository(MongoDatabase db, string tbl)
        {
            database = db;
            tableName = tbl;
            collection = database.GetCollection<T>(tbl);
            
        }


        /** Generic Get method to get record on the basis of id */
        public T Get(int i)
        {
            return collection.FindOneById(i);
        }


        /** Get all records */
        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = collection.FindAll();
            return cursor.AsQueryable<T>();
        }


        /** Generic add method to insert enities to collection */
        public void Add(T entity)
        {
            collection.Insert(entity);
        }


        /** Generic delete method to delete record on the basis of id*/
        public void Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            collection.Remove(query);
        }


        /** Generic update method to delete record on the basis of id*/
        public void Update(Expression<Func<T,int>> queryExpression, int id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            collection.Update(query, Update<T>.Replace(entity));
        }



    }
}
