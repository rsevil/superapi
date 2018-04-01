using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Commands
{
    public class ProductListCreateCommand : IRequest
    {
        public ProductListCreateCommand(Guid id, string name, string userId, IEnumerable<Product> products)
        {
            Id = id;
            Name = name;
            UserId = userId;
            Products = products;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string UserId { get; }
        public IEnumerable<Product> Products { get; }

        public class Product
        {
            public Product(Guid id, int quantity)
            {
                Id = id;
                Quantity = quantity;
            }

            public Guid Id { get; set; }

            public int Quantity { get; set; }
        }
    }
}
