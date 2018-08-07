using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class UserImageConfiguration:EntityTypeConfiguration<UserImage>
    {
        public UserImageConfiguration()
        {
            Property(ui => ui.ImageContent)
                .IsRequired();
        }
    }
}