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
    public class RidehistoriesService : IRidehistoriesService
    {
        private readonly UnitOfWork _sUnitOfwork = new UnitOfWork();

        /** Implemantation of get one Ridehistory records */
        public IQueryable<Ridehistories> Get(string i)
        {
            var rideHistories = _sUnitOfwork.ridehistories.Get(i);
            return (rideHistories);
        }

        /** Implemantation of get all Ridehistory records */
        public IEnumerable<Ridehistories> GetAll()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetAll().ToList();
            if (rideHistories.Any())
            {
                Mapper.CreateMap<Ridehistories, RideHistoriesEntity>();
                var rideHistoriesModel = Mapper.Map<List<Ridehistories>, List<RideHistoriesEntity>>(rideHistories);
                return rideHistories;
            }
            return null;
        }
    }
}
