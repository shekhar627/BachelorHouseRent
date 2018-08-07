using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class AllAddViewModel
    {
        public IEnumerable<Advertisement> Advertisements { get; set; }
        public Division Division { get; set; }
        
    }
}