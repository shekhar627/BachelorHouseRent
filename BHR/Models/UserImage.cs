using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHR.Models
{
    public class UserImage
    {
        public int Id { get; set; }
 
        [Display(Name = "Select Photo")]
        public byte[]  ImageContent { get; set; }
        public string ContentType { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}