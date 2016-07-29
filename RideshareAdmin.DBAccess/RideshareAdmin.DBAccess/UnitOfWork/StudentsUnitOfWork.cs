using MongoDB.Driver;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.DBAccess.Repository;
using System.Configuration;

namespace RideshareAdmin.DBAccess.UnitOfWork
{
    class StudentsUnitOfWork
    {
        /*
        private MongoDatabase _database;

        //protected StudentRepository<Student> _students;
        protected UserRepository<User> _user;

        public StudentsUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }
        //public StudentRepository<Student> Students
        public UserRepository<User> users
        {
            get
            {
                if (_user == null)
                    //_user = new StudentRepository<Student>(_database, "students");
                    _user = new UserRepository<User>(_database, "users");

                return _user;
            }
        }
        */
    }
}
