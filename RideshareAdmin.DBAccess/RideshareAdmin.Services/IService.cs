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
        IQueryable<User> Get(string i);
        UserCalculations GetUserCount();
        IEnumerable<UserEntity> GetAll();
    }

    public interface ICoordinateService
    {
        //IQueryable<Usercoordinate> GetAllCoordinate();
        IEnumerable<CoordinateEntity> GetAllCoordinate();
        //List<Usercoordinate> GetAllCoordinate();
    }

    public interface IRidehistoriesService
    {
        IQueryable<Ridehistories> Get(string i);
        IEnumerable<RideHistoriesEntity> GetAll();
        TotalDistance GetTotalDistance();
        DistanceInDateRange GetTotalDistancefilterbyDateRange(DateTime startDate, DateTime endDate);
        RideHistoryByMonth GetTotalRidesfilterbyCurrentMonth();
        RidesCount GetRidesCount();
    }

}
