using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id);
            builder.Property(s => s.SellerName).HasMaxLength(50).IsRequired();
            builder.Property(s => s.SellerAddress).HasMaxLength(150).IsRequired();
            builder.Property(s => s.SellerNumber).HasMaxLength(11).IsRequired();
        }
    }
}
