using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public UserImage UserImage { get; set; }
        public Document Document { get; set; }
        public string HouseKey { set; get; }
        public HouseKey Key { get; set; }


    }
}