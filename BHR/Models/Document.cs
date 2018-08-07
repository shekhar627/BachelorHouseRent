using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Display(Name = "Upload Your Documents")]
        public byte[]  DocumentContents { get; set; }
        public string ContentType { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}