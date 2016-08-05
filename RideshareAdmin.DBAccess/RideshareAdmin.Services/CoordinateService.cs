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
    public class CoordinateService  : ICoordinateService
    {
        private readonly UnitOfWork _sUnitOfwork1 = new UnitOfWork();

        //public IQueryable<Usercoordinate> GetAllCoordinate()
        //{
        //    return _sUnitOfwork.usercoordinates.GetAll();
        //}
        //public List<Usercoordinate> GetAllCoordinate()
        //{
        //    return _sUnitOfwork.usercoordinates.GetAll();
        //}

        public IEnumerable<CoordinateEntity> GetAllCoordinate()
        {
            var usercoordinates = _sUnitOfwork1.usercoordinates.GetAll().ToList();
            if (usercoordinates.Any())
            {
                Mapper.CreateMap<Usercoordinate, CoordinateEntity>();
                var usercoordinatesModel = Mapper.Map<List<Usercoordinate>, List<CoordinateEntity>>(usercoordinates);
                return usercoordinatesModel;
            }
            return null;

            //return _sUnitOfwork.users.GetAll();
        }


    }
}
