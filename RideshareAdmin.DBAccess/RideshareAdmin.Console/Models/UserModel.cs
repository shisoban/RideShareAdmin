using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideshareAdmin.Console.Models
{
    public class UserModel
    {
        string firstname { get; set; }
        string lastname { get; set; }
        string userName { get; set; }
        string password { get; set; }
        string __V { get; set; }
        string email { get; set; }
    }
}