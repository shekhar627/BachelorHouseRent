using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class ManagerHouse
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        [Required]
        [Display(Name = "Enter Valid House Key")]
        public string Key { get; set; }
        public bool? IsActive { get; set; }
    }
}