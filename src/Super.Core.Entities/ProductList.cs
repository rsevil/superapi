﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class ProductList
    {
        public ProductList(Guid id, string name, IEnumerable<ProductListProduct> productListProducts)
        {
            Id = id;
            Name = name;
            ProductListProducts = productListProducts;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string UserId { get; private set; }

        public virtual IEnumerable<ProductListProduct> ProductListProducts { get; private set; }
    }
}
