using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BHR.Models;

namespace BHR.EntityConfiguration
{
    public class ConfirmPaymentConfiguration:EntityTypeConfiguration<ConfirmPayment>
    {
        public ConfirmPaymentConfiguration()
        {
            Property(cp => cp.AddKey)
                .IsRequired()
                .HasMaxLength(255);

            Property(cp => cp.TransactionId)
                .IsRequired()
                .HasMaxLength(255);

            Property(cp => cp.Mobile)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}