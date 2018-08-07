using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class ManagerHouseConfiguration:EntityTypeConfiguration<ManagerHouse>
    {
        public ManagerHouseConfiguration()
        {
            Property(mh => mh.Key)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}