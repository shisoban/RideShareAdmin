using MongoDB.Driver;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.DBAccess.Repository;
using System.Configuration;

namespace RideshareAdmin.DBAccess.UnitOfWork
{
    public class UserUnitOfWork
    {

        private MongoDatabase _database;
        protected UserRepository<User> _user;
                
        public UserUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];

            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            var
            _database = server.GetDatabase(databaseName);
        }
        public UserRepository<User> users
        {
            get
            {
                if (_user == null)
                _user = new UserRepository<User>(_database, "users");

                return _user;
            }
        }

        public Repository< Uercoordinates>

    }
}
