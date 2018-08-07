using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class ConfirmPayment
    {
        public int Id { get; set; }
        public string  Mobile { get; set; }
        public string TransactionId { get; set; }
        public string AddKey { get; set; }
        public bool IsCheckedByAdmin { get; set; }


    }
}