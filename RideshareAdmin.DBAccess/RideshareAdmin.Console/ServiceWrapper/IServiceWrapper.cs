using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideshareAdmin.Console.ServiceWrapper
{
    interface IServiceWrapper
    {
        Task<string> LoginUser(string username, string email);
    }
}
