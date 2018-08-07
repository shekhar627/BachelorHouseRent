using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11,ErrorMessage = "Maximum 11")]
        [MinLength(11,ErrorMessage = "Minimum 11")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [MaxLength(50)]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        public bool? IsAManager { get; set; }

        public bool IsAHouseOwner { get; set; }


        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //public Occupation Occupation { get; set; }

        //[Display(Name = "Select Your Occupation")]
        //public int OccupationId { get; set; }

        public IList<Occupation> Occupations { get; set; }

        [Display(Name = "Select Your Occupation")]
        public int OccupationId { get; set; }

    }
}