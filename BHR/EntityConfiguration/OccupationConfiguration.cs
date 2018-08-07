using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class OccupationConfiguration:EntityTypeConfiguration<Occupation>
    {
        public OccupationConfiguration()
        {
            Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}