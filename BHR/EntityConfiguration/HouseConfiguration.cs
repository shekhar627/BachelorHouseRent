using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class HouseConfiguration:EntityTypeConfiguration<House>
    {
        public HouseConfiguration()
        {
            Property(h => h.Address)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}