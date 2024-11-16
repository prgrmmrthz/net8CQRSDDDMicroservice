using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class SellerRegistration : Aggregate<Guid>
    {
        private readonly List<SellerItem> _sellerItems = new();
        public IReadOnlyList<SellerItem> SellerItems => _sellerItems.AsReadOnly();

        public Guid SellerId { get; private set; } = default!;
        public string Status { get; private set; } = "pending";

        public int TotalQuantityOfRegisteredItems
        {
            get => SellerItems.Count();
            private set { }
        }

        public static SellerRegistration Create(Guid id,
            Guid sellerId)
        {
            var sellerRegistration = new SellerRegistration
            {
                Id = id,
                Status = "pending",
                SellerId = sellerId
            };

            sellerRegistration.AddDomainEvent(new SellerRegistrationCreatedEvent(sellerRegistration));

            return sellerRegistration;
        }

        public void Update(string status)
        {
            Status = status;

            AddDomainEvent(new SellerRegistrationUpdatedEvent(this));
        }

        public void Add(ProductId productId, decimal price, int quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var sellerItem = new SellerItem(Id, productId, price, quantity);

            _sellerItems.Add(sellerItem);
        }

        public void Remove(ProductId productId)
        {
            var sellerItem = _sellerItems.FirstOrDefault(x => x.ProductId == productId);
            if (sellerItem is not null)
            {
                _sellerItems.Remove(sellerItem);
            }
        }

    }
}
