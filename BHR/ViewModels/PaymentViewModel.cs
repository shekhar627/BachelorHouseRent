using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class PaymentViewModel
    {
        public List<PaymentMethod> PaymentMethods { get; set; }

        [Display(Name = "Please Select Payment Method")]
        public int PaymentId { get; set; }

    }
}