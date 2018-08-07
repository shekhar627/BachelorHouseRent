using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class CreateHouseViewModel
    {
        public IList<Division> Divisions { get; set; }
        public IList<District> Districts { get; set; }
        public IList<Thana> Thanas { get; set; }

        [Display(Name = "User Id")]
        public string  UserId{ get; set; }


        public int?  user_id { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Select Your District")]
        public int DistrictId { get; set; }

        [Display(Name = "Select Your Division")]
        public int DivisionId { get; set; }

        [Display(Name = "Select Your Thana")]
        public int ThanaId { get; set; }



    }
}