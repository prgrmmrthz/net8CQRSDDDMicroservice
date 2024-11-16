using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class SellerItem : Aggregate<Guid>
    {
        internal SellerItem(Guid sellerRegistrationId, ProductId productId,
            decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            SellerRegistrationId = sellerRegistrationId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public Guid SellerRegistrationId { get; private set; } = default!;
        public ProductId ProductId { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public int Quantity { get; private set; } = default!;

    }
}
