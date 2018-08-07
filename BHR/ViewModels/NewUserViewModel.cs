using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class NewUserViewModel
    {
        public User User { get; set; }
        public List<Occupation> Occupations { get; set; }

    }
}