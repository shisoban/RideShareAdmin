using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RideshareAdmin.WebUI.Models
{
    public class DashboardVIewModel
    {
        public string Noofkillometer { get; set; }
        public decimal Noofusers { get; set; }
    }
}