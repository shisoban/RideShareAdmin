using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.DBAccess.UnitOfWork;
using AutoMapper;
using BusinessEntities;

namespace RideshareAdmin.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _sUnitOfwork = new UnitOfWork();


        public IQueryable<User> Get(string i)
        {
            var user = _sUnitOfwork.users.Get(i);
            return (user);
        }

        // Get All Details
        public IEnumerable<UserEntity> GetAll()
        {
            var users = _sUnitOfwork.users.GetAll().ToList();
            if (users.Any())
            {
                Mapper.CreateMap<User, UserEntity>();
                var usersModel = Mapper.Map<List<User>, List<UserEntity>>(users);
                return usersModel;
            }
            return null;
        }

        //Get users count
        public UserCalculations GetUserCount()
        {
            var usercount = _sUnitOfwork.users.GetAll().Count();
            UserCalculations count = new UserCalculations();
            count.userCount = usercount;
            return count;
        }
    }
}

