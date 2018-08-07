using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class HouseKey
    {
        public int Id { get; set; }
        public House House { get; set; }
        public int HouseId { get; set; }
        public string Key { get; set; }

        [Required]
        [Display(Name = "Enter Flat No / Name")]
        public string FlatName { get; set; }


    }
}