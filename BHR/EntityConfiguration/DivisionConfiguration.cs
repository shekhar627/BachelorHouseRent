using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class DivisionConfiguration:EntityTypeConfiguration<Division>
    {
        public DivisionConfiguration()
        {
            Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}