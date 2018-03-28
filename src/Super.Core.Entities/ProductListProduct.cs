using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductListProduct
    {
        public ProductListProduct(Guid productListId, Guid productId)
        {
            ProductListId = productListId;
            ProductId = productId;
        }

        public Guid ProductListId { get; private set; }
        public Guid ProductId { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
