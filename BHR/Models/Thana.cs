using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class Thana
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }


    }
}