using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class CreateAddViewModel
    {
        public List<Division> Divisions { get; set; }
        public List<District> Districts { get; set; }
        public List<Thana> Thanas { get; set; }

        [Required]
        [Display(Name = "Select District")]
        public int DistrictId { get; set; }

        [Required]
        [Display(Name = "Select Thana")]
        public int ThanaId { get; set; }

        [Required]
        [Display(Name = "Select Division")]
        public int DivisionId { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Ending Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Just Write Your Content Here")]
        public string Description { get; set; }

    
        public byte[] Contents { get; set; }


    }
}