using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UserEntity
    {
       // public string _id { get; set; }
        //public ObjectId Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
      //  public string password { get; set; }
     //   public int __v { get; set; }
        public string email { get; set; }
    }

    public class CoordinateEntity
    {
       // public string _id { get; set; }
        //public ObjectId Id { get; set; }
        //public string userName { get; set; }
        public string email { get; set; }
        public string name { get; set; }
       // public double longitude { get; set; }
        //public double latitude { get; set; }
      //  public int __v { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNo { get; set; }
       // public int userType { get; set; }
    }
}
