using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class AdvertiseImage
    {
        public int Id { get; set; }
        public byte[] Contents { get; set; }
        public string ContentType { get; set; }
        public Advertisement Advertisement { get; set; }
        public int AdvertisementId { get; set; }

    }
}