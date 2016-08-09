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

        public RidesCount GetRidesCount()
        {
            var ridesCount = _sUnitOfwork.ridehistories.GetAll().Count();
            RidesCount count = new RidesCount();
            count.ridesCount = ridesCount;
            return count;

            //return _sUnitOfwork.users.GetAll();
        }

        public TotalDistance GetTotalDistance()
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;

            TotalDistance totalDistance = new TotalDistance();

            foreach(Ridehistories ride in rideHistory)
            {
                if (ride.distance != null && ride.requestStatus==2) { 
                string[] splitstringdistance = ride.distance.Split(null);
                string stringdistance = splitstringdistance[0];
                double doubledistance = double.Parse(stringdistance, System.Globalization.CultureInfo.InvariantCulture);
                sum = sum + doubledistance;
                }
            }
            totalDistance.totalDistance = sum;
            return totalDistance;


        }

        public DistanceInDateRange GetTotalDistancefilterbyDateRange(DateTime startDate, DateTime endDate)
        {
            
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;

            DistanceInDateRange totalDistance = new DistanceInDateRange();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.distance != null && ride.requestStatus == 2 && ride.requestedTime>startDate && ride.requestedTime<endDate)
                {
                    string[] splitstringdistance = ride.distance.Split(null);
                    string stringdistance = splitstringdistance[0];
                    double doubledistance = double.Parse(stringdistance, System.Globalization.CultureInfo.InvariantCulture);
                    sum = sum + doubledistance;
                }
            }
            totalDistance.distanceInDateRange = sum;
            return totalDistance;


        }

        public RideHistoryByMonth GetTotalRidesfilterbyCurrentMonth()
        {
            int sMonth = DateTime.Now.Month;
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            int sum = 0;

            RideHistoryByMonth totalrides = new RideHistoryByMonth();

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


    }
}
