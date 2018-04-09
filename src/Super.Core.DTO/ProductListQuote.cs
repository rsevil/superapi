using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.DTO
{
    public class ProductListQuote
    {
        public Guid StoreId { get; set; }

        public string StoreName { get; set; }

        public string Address { get; set; }

        public decimal Score { get; set; }

        public decimal Amount { get; set; }

        public decimal Distance { get; set; }

        public string DistanceInKm => (Distance / 1000).ToString("#0.00");
    }
}
