using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RideshareAdmin.DBAccess.Models;
using System.Linq;

namespace RideshareAdmin.DBAccess.Repository
{
    public class DriverGraphRepository : Repository<Ridehistories>
    {
        public DriverGraphRepository(MongoDatabase db, string tblName) : base(db, tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<Ridehistories>(tblName);
        }

        // Get  method to retrieve ride histories
        public new IQueryable<Ridehistories> Get(string i)
        {
            //var group = collection.Aggregate()
            //          .Match(filter)
            //          .Group(new BsonDocument {
            //              { "_id", new BsonDocument {
            //                  { "month", new BsonDocument("$month", "$createddate.DateTime") },
            //                  { "day", new BsonDocument("$dayOfMonth", "$createddate.DateTime") },
            //                  { "year", new BsonDocument("$year", "$createddate.DateTime") } } },
            //              { "count", new BsonDocument("$sum", 1) } })
            //          .ToListAsync().Result;





            var query = Query.EQ("driverName", i);
            MongoCursor<Ridehistories> cursor = _collection.Find(query);
            return cursor.AsQueryable<Ridehistories>();
        }

    }
}
