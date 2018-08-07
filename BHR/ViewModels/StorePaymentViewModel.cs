using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.ViewModels
{
    public class StorePaymentViewModel
    {
        public ConfirmPayment ConfirmPayment { get; set; }
        public string  AgentNumber { get; set; }

        [Required]
        [Display(Name = "Your Advertisement Key")]
        public string AddKey { get; set; }

        [Required]
        [Display(Name = "Your Phone Number")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Transaction Id")]
        public string TransactionId { get; set; }

    }
}