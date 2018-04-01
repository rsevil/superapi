using System;
using System.Collections.Generic;

namespace Super.Core.Commands
{
    public class ProductListUpdateCommand : ProductListCreateCommand
    {
        public ProductListUpdateCommand(Guid id, string name, string userId, IEnumerable<Product> products) 
            : base(id, name, userId, products)
        {
        }
    }
}
