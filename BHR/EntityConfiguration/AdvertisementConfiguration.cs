using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class AdvertisementConfiguration:EntityTypeConfiguration<Advertisement>
    {
        public AdvertisementConfiguration()
        {
            Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(255);
            Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(a=>a.Division)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasRequired(a => a.District)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Thana)
                .WithMany()
                .WillCascadeOnDelete(false);

            Property(a => a.Price)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}