using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductPrice
    {
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public Guid StoreId { get; private set; }

        public decimal Price { get; private set; }

        public DateTimeOffset ValidFrom { get; private set; }

        public DateTimeOffset? ValidTo { get; private set; }
    }
}
