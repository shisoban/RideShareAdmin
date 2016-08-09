using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideshareAdmin.Console.Models
{
    public class RideListViewModel
    {
        public List<RideHistoriesEntity> RideList { get; set; }
    }
}