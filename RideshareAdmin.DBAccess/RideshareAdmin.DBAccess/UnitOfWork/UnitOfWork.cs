using MongoDB.Driver;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.DBAccess.Repository;
using System.Configuration;

namespace RideshareAdmin.DBAccess.UnitOfWork
{
    public class UnitOfWork
    {

        private MongoDatabase _database1;
        private MongoDatabase _database2;

        ////////////////Generic Repositiry////////////////
        //protected Repository<User> _user;
        //protected Repository<Usercoordinate> _usercoordinate;
        //protected Repository<Ridehistories> _ridehistories;
        //////////////////////////////////////////////////

        protected UserRepository<User> _user;
        protected UsercoordinatesRepository<Usercoordinate> _usercoordinate;
        protected RideHistoryRepository<Ridehistories> _ridehistories;



        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];

            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            var databaseName1 = ConfigurationManager.AppSettings["MongoDBDatabaseName1"];
            _database1 = server.GetDatabase(databaseName1);

            // database connections for the 
            var databaseName2 = ConfigurationManager.AppSettings["MongoDBDatabaseName2"];
            _database2 = server.GetDatabase(databaseName2);
        }

        //////////////////////////////////Generic Repository////////////////////////////////////////////

        //public Repository<User> users
        //{
        //    get
        //    {
        //        if (_user == null)
        //            _user = new Repository<User>(_database1, "users");

        //        return _user;
        //    }
        //}

        //public Repository<Usercoordinate> usercoordinates
        //{
        //    get
        //    {
        //        if (_usercoordinate == null)
        //            _usercoordinate = new Repository<Usercoordinate>(_database2, "usercoordinates");

        //        return _usercoordinate;
        //    }
        //}

        //public Repository<Ridehistories> ridehistories
        //{
        //    get
        //    {
        //        if (_ridehistories == null)
        //            _ridehistories = new Repository<Ridehistories>(_database2, "ridehistories");

        //        return _ridehistories;
        //    }
        //}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public UserRepository<User> users
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository<User>(_database1, "users");

                return _user;
            }
        }

        public UsercoordinatesRepository<Usercoordinate> usercoordinates
        {
            get
            {
                if (_usercoordinate == null)
                    _usercoordinate = new UsercoordinatesRepository<Usercoordinate>(_database2, "usercoordinates");

                return _usercoordinate;
            }
        }

        public RideHistoryRepository<Ridehistories> ridehistories
        {
            get
            {
                if (_ridehistories == null)
                    _ridehistories = new RideHistoryRepository<Ridehistories>(_database2, "ridehistories");

                return _ridehistories;
            }
        }


    }
}
