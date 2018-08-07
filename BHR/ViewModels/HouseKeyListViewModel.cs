using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class HouseKeyListViewModel
    {
        public IEnumerable<HouseKey> HouseKeys { get; set; }
        public int House_Id { get; set; }

    }
}