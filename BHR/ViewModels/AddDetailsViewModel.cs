using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class AddDetailsViewModel
    {
        public Advertisement Advertisement { get; set; }
        public IEnumerable<AdvertiseImage> AdvertiseImages { get; set; }
        public Division Division { get; set; }
        public District District { get; set; }
        public Thana Thana { get; set; }
    }
}