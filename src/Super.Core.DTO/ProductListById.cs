using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.DTO
{
    public class ProductListById
    {
        public ProductListById(Guid id, string name, IEnumerable<Product> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        public class Product
        {
            public Product(Guid id, string name, string photoUrl, int quantity)
            {
                Id = id;
                Name = name;
                PhotoUrl = photoUrl;
                Quantity = quantity;
            }

            public Guid Id { get; set; }
            public string Name { get; private set; }
            public string PhotoUrl { get; private set; }
            public int Quantity { get; }
        }
    }
}
