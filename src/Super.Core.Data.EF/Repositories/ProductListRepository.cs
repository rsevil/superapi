using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data.EF.Repositories
{
    public class ProductListRepository : IProductListRepository
    {
        private readonly DataContext dataContext;

        public ProductListRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Add(ProductList productList)
        {
            dataContext.ProductLists.Add(productList);
        }

        public void AttachProductListProduct(ProductListProduct productListProduct)
        {
            dataContext.Attach(productListProduct);
        }
    }
}
