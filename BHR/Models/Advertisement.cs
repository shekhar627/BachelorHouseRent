using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Division Division { get; set; }
        public int DivisionId { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }
        public Thana Thana { get; set; }
        public int ThanaId { get; set; }
        public string Address { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Price { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        public string Key { get; set; }


    }
}