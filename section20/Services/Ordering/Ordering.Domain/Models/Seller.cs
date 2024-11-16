using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Seller : Aggregate<Guid>
    {
        public string SellerName { get; private set; } = default!;
        public string SellerAddress { get; private set; } = default!;
        public string SellerNumber { get; private set; } = default!;
        
        public static Seller Create(Guid id,
               string sellerName,
               string sellerAddress,
               string sellerNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sellerName);
            ArgumentException.ThrowIfNullOrWhiteSpace(sellerAddress);

            var seller = new Seller
            {
                Id = id,
                SellerName = sellerName,
                SellerAddress = sellerAddress,
                SellerNumber = sellerNumber
            };

            return seller;
        }
      
    }
}
