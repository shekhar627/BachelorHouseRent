using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class House
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Thana Thana { get; set; }

        public int ThanaId { get; set; }

    }
}