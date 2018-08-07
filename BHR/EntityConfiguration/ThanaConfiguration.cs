using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class ThanaConfiguration:EntityTypeConfiguration<Thana>
    {
        public ThanaConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}