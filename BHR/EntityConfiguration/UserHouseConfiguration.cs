using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class UserHouseConfiguration:EntityTypeConfiguration<UserHouse>
    {
        public UserHouseConfiguration()
        {
            Property(uh => uh.UserId)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}