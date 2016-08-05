using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideshareAdmin.DBAccess.Models;
using BusinessEntities;


namespace  RideshareAdmin.Services
{
    public interface IUserService
    {
        // void Insert(User user);
        IQueryable<User> Get(string i);
        //  test();
        UserCalculations GetUserCount();
        IEnumerable<UserEntity> GetAll();
        //List<User> GetAll();
        // void Delete(int id);
        // void Update(User user);

    }

    public interface ICoordinateService
    {
        //IQueryable<Usercoordinate> GetAllCoordinate();
        IEnumerable<CoordinateEntity> GetAllCoordinate();
        //List<Usercoordinate> GetAllCoordinate();
    }
}
