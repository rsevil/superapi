using Microsoft.EntityFrameworkCore;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Core.Data.EF.Repositories
{
    public class ProductListRepository : IProductListRepository
    {
        private readonly DataContext dataContext;

        public ProductListRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<ProductList> Find(Guid id)
        {
            return await dataContext.ProductLists
                .Include(x => x.ProductListProducts)
                .ThenInclude(x => x.Product)
                .SingleAsync(x => x.Id == id);
        }

        public void Add(ProductList productList)
        {
            dataContext.ProductLists.Add(productList);
        }

        public void AddProductListProduct(ProductListProduct productListProduct)
        {
            dataContext.Add(productListProduct);
        }

        public void Delete(Guid id)
        {
            var e = Activator.CreateInstance(typeof(ProductList), nonPublic: true);
            typeof(ProductList).GetProperty(nameof(ProductList.Id)).SetValue(e, id);
            dataContext.Remove(e);
        }

        public void AttachProductListProduct(ProductListProduct productListProduct)
        {
            dataContext.Attach(productListProduct);
        }

        public void Update(ProductList productList)
        {
            dataContext.ProductLists.Update(productList);
        }
    }
}
