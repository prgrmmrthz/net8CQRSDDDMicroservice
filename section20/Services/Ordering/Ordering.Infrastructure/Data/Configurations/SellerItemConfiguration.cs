using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class SellerItemConfiguration : IEntityTypeConfiguration<SellerItem>
    {
        public void Configure(EntityTypeBuilder<SellerItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x =>x.Price).IsRequired();
        }
    }
}
