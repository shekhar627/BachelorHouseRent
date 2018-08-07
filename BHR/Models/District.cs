using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Division Division { get; set; }
        public int DivisionId { get; set; }


    }
}