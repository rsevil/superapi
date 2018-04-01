using System;
using System.Threading.Tasks;
using Super.Core.Entities;

namespace Super.Core.Data.Repositories
{
    public interface IProductListRepository
    {
        Task<ProductList> Find(Guid id);

        void Add(ProductList productList);

        void AddProductListProduct(ProductListProduct productListProduct);

        void Delete(Guid id);
        void AttachProductListProduct(ProductListProduct productListProduct);
        void Update(ProductList productList);
    }
}
