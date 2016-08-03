﻿using System;
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
        private readonly UserUnitOfWork _sUnitOfwork = new UserUnitOfWork();


        public IQueryable<User> Get(string i)
        {
            var user = _sUnitOfwork.users.Get(i);
            return (user);
        }


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

            //return _sUnitOfwork.users.GetAll();
        }

        //public void Delete(int id)
        //{
        //    _sUnitOfwork.users.Delete(s => s.userID, id);
        //}

        //public void Insert(User user)
        //{
        //    _sUnitOfwork.users.Add(user);
        //}

        //public void Update(User user)
        //{
        //    _sUnitOfwork.users.Update(s => s.userID, user.userID,user);
        //}

    }
}

