using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Add(Product product)
        {
            dataContext.Add(product);
        }
    }
}
