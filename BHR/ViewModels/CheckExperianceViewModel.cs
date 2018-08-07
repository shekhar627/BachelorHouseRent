using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class CheckExperianceViewModel
    {
        public List<House> Houses { get; set; }
        public List<ManagerHouse> ManagerHouses { get; set; }
    }
}