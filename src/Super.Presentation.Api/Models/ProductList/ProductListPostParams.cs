using System;
using System.Collections.Generic;

namespace Super.Presentation.Api.Models.ProductList
{
    public class ProductListPostParams
    {
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public string UserId { get; set; }

        public class Product
        {
            public Guid Id { get; set; }

            public int Quantity { get; set; }
        }
    }
}
