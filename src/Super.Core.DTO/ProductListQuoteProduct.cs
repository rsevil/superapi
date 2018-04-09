using System;

namespace Super.Core.DTO
{
    public class ProductListQuoteProduct
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public decimal Amount { get; private set; }

        public int Quantity { get; private set; }
    }
}
