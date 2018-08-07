using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class NewManagerWithExistingManagerViewModel
    {
        public ManagerHouse ManagerHouse { get; set; }
        [Required]
        [Display(Name = "Enter User Id")]
        public string UserId { get; set; }

    }
}