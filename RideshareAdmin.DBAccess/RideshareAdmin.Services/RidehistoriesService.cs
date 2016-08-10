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
            //var ridesCount = _sUnitOfwork.ridehistories.GetAll().Count();
            //RidesCount count = new RidesCount();
            //count.ridesCount = ridesCount;
            //return count;

            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            int activeRideCount = 0;

            RidesCount rideCountObject = new RidesCount();

            foreach (Ridehistories rideHistoryTable in rideHistory)
            {
                if (rideHistoryTable.requestStatus == 2)
                {
                    activeRideCount = activeRideCount+1;
                }
            }

            rideCountObject.ridesCount = activeRideCount;
            return rideCountObject;

        }

        public TotalDistance GetTotalDistance()
        {
            var rideHistory = _sUnitOfwork.ridehistories.GetAll().ToList();
            double sum = 0;

            TotalDistance totalDistance = new TotalDistance();

            foreach (Ridehistories ride in rideHistory)
            {
                if (ride.distance != 0 && ride.requestStatus == 2)
                {
                    /* changed due to db change of column from string to double */
                    //string[] splitstringdistance = ride.distance.Split(null);
                    //string stringdistance = splitstringdistance[0];
                    // double doubledistance = double.Parse(stringdistance, System.Globalization.CultureInfo.InvariantCulture);
                    sum = sum + ride.distance;
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
                if (ride.distance != 0 && ride.requestStatus == 2 && ride.requestedTime>startDate && ride.requestedTime<endDate)
                {
                    /* changed due to db change of column from string to double */

                    //string[] splitstringdistance = ride.distance.Split(null);
                     // string stringdistance = splitstringdistance[0];                  
                    //double distance = double.Parse(ride.distance, System.Globalization.CultureInfo.InvariantCulture);
                    sum = sum + ride.distance;
                }
            }
            totalDistance.distanceInDateRange = sum;
            return totalDistance;


        }

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
