using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class DistrictConfiguration:EntityTypeConfiguration<District>
    {
        public DistrictConfiguration()
        {
            Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(225);
        }
    }
}