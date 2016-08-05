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
        protected Repository<User> _user;
       protected Repository<Usercoordinate> _usercoordinate;

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
        public Repository<User> users
        {
            get
            {
                if (_user == null)
                    _user = new Repository<User>(_database1, "users");

                return _user;
            }
        }

        public Repository<Usercoordinate> usercoordinates
        {
            get
            {
                if (_usercoordinate == null)
                    _usercoordinate = new Repository<Usercoordinate>(_database2, "usercoordinates");

                return _usercoordinate;
            }
        }

    }
}
