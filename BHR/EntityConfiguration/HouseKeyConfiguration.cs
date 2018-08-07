using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class HouseKeyConfiguration:EntityTypeConfiguration<HouseKey>
    {
        public HouseKeyConfiguration()
        {
            Property(hk => hk.Key)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Key"){IsUnique = true}));
            Property(hk => hk.FlatName)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}