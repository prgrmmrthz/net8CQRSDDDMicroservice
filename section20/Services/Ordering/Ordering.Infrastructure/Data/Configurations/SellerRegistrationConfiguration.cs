using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class SellerRegistrationConfiguration : IEntityTypeConfiguration<SellerRegistration>
    {
        public void Configure(EntityTypeBuilder<SellerRegistration> builder)
        {
            builder.HasKey(sr => sr.Id);
            builder.Property(sr => sr.Id);
            builder.HasOne<Seller>()
                .WithMany()
                .HasForeignKey(sr => sr.SellerId)
                .IsRequired();

            builder.HasMany<SellerItem>(sr => sr.SellerItems)
                .WithOne()
                .HasForeignKey(si => si.SellerRegistrationId);

            builder.Property(sr => sr.Status);
            builder.Property(sr => sr.TotalQuantityOfRegisteredItems);
        }
    }
}
