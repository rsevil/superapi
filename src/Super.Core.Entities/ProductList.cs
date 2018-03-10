using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductList
    {
        public Guid Id { get; private set; }

        public string UserId { get; private set; }

        public IEnumerable<Product> Products { get; private set; }
    }
}
