using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;
using System.Data.Entity.Infrastructure.Annotations;

namespace BHR.EntityConfiguration
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.MobileNumber)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.UserId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UserId"){IsUnique = true}));

            Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.ConfirmPassword)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}