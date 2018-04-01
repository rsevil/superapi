using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductListProduct
    {
        private ProductListProduct()
        {
        }

        public ProductListProduct(Guid productListId, Guid productId, int quantity)
        {
            ProductListId = productListId;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductListId { get; private set; }
        public Guid ProductId { get; private set; }
        public virtual Product Product { get; private set; }
        public int Quantity { get; private set; }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
