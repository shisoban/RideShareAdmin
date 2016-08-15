using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RideshareAdmin.DBAccess.Models;
using System.Linq;

namespace RideshareAdmin.DBAccess.Repository
{
    public class InheritRideHistoryRepository : Repository<Ridehistories>
    {
        public InheritRideHistoryRepository(MongoDatabase db, string tblName) : base(db, tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<Ridehistories>(tblName);
        }

        // Get  method to retrieve ride histories
        public new IQueryable<Ridehistories> Get(string i)
        {
            var query = Query.EQ("driverName", i);
            MongoCursor<Ridehistories> cursor = _collection.Find(query);
            return cursor.AsQueryable<Ridehistories>();
        }

    }
}