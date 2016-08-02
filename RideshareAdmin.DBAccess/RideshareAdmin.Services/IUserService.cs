using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideshareAdmin.DBAccess.Models;


namespace  RideshareAdmin.Services
{
    public interface IUserService
    {
       // void Insert(User user);
        User Get(int i);
      //  test();
        IQueryable<User> GetAll();
       // void Delete(int id);
       // void Update(User user);

    }
}
