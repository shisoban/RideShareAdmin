﻿using System;
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
        IQueryable<User> Get(string i);
        UserCalculations GetUserCount();
        IEnumerable<UserEntity> GetAll();
    }

    public interface ICoordinateService
    {
        IEnumerable<CoordinateEntity> GetAllCoordinate();
        UserCalculations GetUserCount();
    }

    public interface IRidehistoriesService
    {
        IQueryable<Ridehistories> Get(string i);
        IEnumerable<RideHistoriesEntity> GetAll();
        TotalDistance GetTotalDistance();
        Emission GetEmission();
        Emission GetTotalEmission();     
        IEnumerable<RidesByLocationDetailEntity> GetRidesByLocation();
        DistanceInDateRange GetTotalDistancefilterbyDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<RideHistoriesEntity> RideListInDateRange(DateTime startDate, DateTime endDate);
        RideHistoryByCurrentMonth GetTotalRidesfilterbyCurrentMonth();
        RidesCount GetRidesCount();
        IEnumerable<RideCountByDriveDetailEntity> GetRideCountByDrivers();
        IEnumerable<GetDistanceByMonthDetailEntity> GetDistanceByMonth();
        IEnumerable<RideCountByUserDetailEntity> GetTopRiders();
    }

}
