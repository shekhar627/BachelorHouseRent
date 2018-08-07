using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        public bool? IsAManager { get; set; }

        public bool IsAHouseOwner { get; set; }

        public bool?  IsValid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Occupation Occupation { get; set; }

        [Display(Name = "Select Your Occupation")]
        public int OccupationId { get; set; }


    }
}