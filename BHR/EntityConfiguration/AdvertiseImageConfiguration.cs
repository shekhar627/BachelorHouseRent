using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class AdvertiseImageConfiguration:EntityTypeConfiguration<AdvertiseImage>
    {
        public AdvertiseImageConfiguration()
        {
            Property(ai => ai.Contents)
                .IsRequired();

            Property(ai => ai.ContentType)
                .IsRequired();
        }
    }
}