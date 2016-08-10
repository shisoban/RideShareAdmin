using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideshareAdmin.Console.Models
{
    public class RideListViewModel
    {
        public string startdate { get; set; }
        public string enddate { get; set; }
        public List<RideHistoriesEntity> RideList { get; set; }
    }
}