using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductList
    {
        private ProductList()
        {
            ProductListProducts = new Collection<ProductListProduct>();
        }

        public ProductList(
            Guid id,
            string name,
            string userId,
            IEnumerable<ProductListProduct> productListProducts)
            : this()
        {
            Id = id;
            Name = name;
            UserId = userId;
            ProductListProducts = productListProducts.ToList();
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string UserId { get; private set; }

        public virtual ICollection<ProductListProduct> ProductListProducts { get; private set; }

        public void Update(string name, IEnumerable<ProductListProduct> products)
        {
            Name = name;

            // process updates
            foreach (var product in products)
            {
                var item = ProductListProducts.FirstOrDefault(x => x.ProductId == product.ProductId);

                // update
                if (item != null)
                {
                    item.UpdateQuantity(product.Quantity);
                }
                //else // create
                //{
                //    ProductListProducts.Add(product);
                //}
            }

            // process deletions
            var deletedProducts = ProductListProducts
                .Where(x => !products.Any(y => y.ProductId == x.ProductId))
                .ToList();

            foreach (var product in deletedProducts)
            {
                ProductListProducts.Remove(product);
            }
        }
    }
}
