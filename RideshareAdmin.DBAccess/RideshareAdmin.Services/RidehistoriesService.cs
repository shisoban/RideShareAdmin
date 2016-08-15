using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.DBAccess.UnitOfWork;
using AutoMapper;
using BusinessEntities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;


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
        public IEnumerable<RideHistoriesEntity> GetAll()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetAll().ToList();
            if (rideHistories.Any())
            {

                Mapper.CreateMap<Ridehistories, RideHistoriesEntity>();
                var rideHistoriesModel = Mapper.Map<List<Ridehistories>, List<RideHistoriesEntity>>(rideHistories);
                return rideHistoriesModel;
            }
            return null;
        }

        /** Implemantation of get rides count Ridehistory records */
        public RidesCount GetRidesCount()
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            int activeRideCount = 0;

            RidesCount rideCountObject = new RidesCount();

            foreach (Ridehistories rideHistoryTable in rideHistory)
            {
                if (rideHistoryTable.requestStatus == 2)
                {
                    activeRideCount = activeRideCount + 1;
                }
            }
            rideCountObject.ridesCount = activeRideCount;
            return rideCountObject;
        }

        /** Implemantation of get total distance Ridehistory records */
        public TotalDistance GetTotalDistance()
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;

            TotalDistance totalDistance = new TotalDistance();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.distance != 0 && ride.requestStatus == 2)
                {
                    sum = sum + ride.distance;
                }
            }
            totalDistance.totalDistance = sum;
            return totalDistance;
        }

        /** Implemantation of get total distance filter by date range */
        public DistanceInDateRange GetTotalDistancefilterbyDateRange(DateTime startDate, DateTime endDate)
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;

            DistanceInDateRange totalDistance = new DistanceInDateRange();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.distance != 0 && ride.requestStatus == 2 && ride.requestedTime > startDate && ride.requestedTime < endDate)
                {
                    sum = sum + ride.distance;
                }
            }
            totalDistance.distanceInDateRange = sum;
            return totalDistance;
        }

        /** Implemantation of get Ride List In DateRange*/
        public IEnumerable<RideHistoriesEntity> RideListInDateRange(DateTime startDate, DateTime endDate)
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();

            List<Ridehistories> rideListDBModel = new List<Ridehistories>();
            RideHistoriesEntity rideList = new RideHistoriesEntity();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.requestStatus == 2 && ride.requestedTime > startDate && ride.requestedTime < endDate)
                {
                    rideListDBModel.Add(ride);
                }
            }
            Mapper.CreateMap<Ridehistories, RideHistoriesEntity>();
            var rideHistoriesInDateRange = Mapper.Map<List<Ridehistories>, List<RideHistoriesEntity>>(rideListDBModel);
            return rideHistoriesInDateRange;
        }

        /** Implemantation of get ride history by current month*/
        public RideHistoryByCurrentMonth GetTotalRidesfilterbyCurrentMonth()
        {
            int sMonth = DateTime.Now.Month;
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            int sum = 0;

            RideHistoryByCurrentMonth totalrides = new RideHistoryByCurrentMonth();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.requestStatus == 2 && ride.requestedTime.Month == sMonth)
                {
                    sum++;
                }
            }
            totalrides.totalRides = sum;
            return totalrides;

        }

        /** Implemantation of get get rides by location*/
        public IEnumerable<RidesByLocationDetailEntity> GetRidesByLocation()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetRidesCountByLocation().ToList();
            List<RidesByLocationEntity> returnValue = new List<RidesByLocationEntity>();
            returnValue.AddRange(rideHistories.Select(x => BsonSerializer.Deserialize<RidesByLocationEntity>(x)));
            {
                Mapper.CreateMap<RidesByLocationEntity, RidesByLocationDetailEntity>();
                var usersModel = Mapper.Map<List<RidesByLocationEntity>, List<RidesByLocationDetailEntity>>(returnValue);
                return usersModel;
            }
           
        }

        /** Get Emission for current Month*/
        public Emission GetEmission()
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;
            
            int sMonth = DateTime.Now.Month;
            foreach (var ride in rideHistory)
            {
                if (ride.distance != 0 && ride.requestStatus == 2 && ride.requestedTime.Month == sMonth)
                {
                    sum = sum + ride.distance;
                }
            }
            var totalDistance = sum;
            Emission emission = new Emission();
            emission.emission = ((totalDistance * 130) / 1000);

            return emission;
        }

        /** This method for to get get ride count by drivers*/
        public IEnumerable<RideCountByDriveDetailEntity> GetRideCountByDrivers()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetRideCountByDriver().ToList();
            List<RideCountByDriverEntity> returnValue = new List<RideCountByDriverEntity>();
            returnValue.AddRange(rideHistories.Select(x => BsonSerializer.Deserialize<RideCountByDriverEntity>(x)));
            {
                Mapper.CreateMap<RideCountByDriverEntity, RideCountByDriveDetailEntity>();
                var usersModel = Mapper.Map<List<RideCountByDriverEntity>, List<RideCountByDriveDetailEntity>>(returnValue);
                return usersModel;
            }
        }

        /**Total emission for total rides */
        public Emission GetTotalEmission()
        {
            var totalDistance = GetTotalDistance().totalDistance;
            Emission emission = new Emission();
            emission.emission = ((totalDistance * 130) / 1000);
            return emission;
        }

        /**Get distance by month */
        public IEnumerable<GetDistanceByMonthDetailEntity> GetDistanceByMonth()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetDistanceByMonth().ToList();

            List<GetDistanceByMonthEntity> returnValue = new List<GetDistanceByMonthEntity>();
            returnValue.AddRange(rideHistories.Select(x => BsonSerializer.Deserialize<GetDistanceByMonthEntity>(x)));
            {
                Mapper.CreateMap<GetDistanceByMonthEntity, GetDistanceByMonthDetailEntity>();
                var usersModel = Mapper.Map<List<GetDistanceByMonthEntity>, List<GetDistanceByMonthDetailEntity>>(returnValue);
                return usersModel;
            }
        }

        /**Top 5 User Most travelled */
        public IEnumerable<RideCountByUserDetailEntity> GetTopRiders()
        {
            var rideHistories = _sUnitOfwork.ridehistories.GetTopRidersTravelled().ToList();
            List<RideCountByUserEntity> returnValue = new List<RideCountByUserEntity>();
            returnValue.AddRange(rideHistories.Select(x => BsonSerializer.Deserialize<RideCountByUserEntity>(x)));
            {
                Mapper.CreateMap<RideCountByUserEntity, RideCountByUserDetailEntity>();
                var usersModel = Mapper.Map<List<RideCountByUserEntity>, List<RideCountByUserDetailEntity>>(returnValue);
                return usersModel;
            }

        }

    }
}
