using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.ViewModels
{
    public class UserLoginViewModel
    {

        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }

    }
}