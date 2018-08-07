using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class UserHouse
    {
        public int Id { get; set; }

        [Display(Name = "User Id")]
        [Required]
        public string UserId { get; set; }
        public HouseKey HouseKey { get; set; }
        public int HouseKeyId { get; set; }
        public bool? IsActive { get; set; }


    }
}