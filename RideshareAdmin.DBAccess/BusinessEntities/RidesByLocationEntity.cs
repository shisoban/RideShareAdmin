using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RidesByLocationEntity
    {
        public RideHistoriesEntity _id { get; set; }
        public int noOfUsersByLocation { get; set; }
        public string destinationName { get { return _id.destinationName; } set { } }


    }

    public class RidesByLocationDetailEntity
    {
        public int noOfUsersByLocation { get; set; }
        public string destinationName { get; set; }
    }
}
