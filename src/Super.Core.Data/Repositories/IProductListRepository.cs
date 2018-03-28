using Super.Core.Entities;

namespace Super.Core.Data.Repositories
{
    public interface IProductListRepository
    {
        void Add(ProductList productList);

        void AttachProductListProduct(ProductListProduct productListProduct);
    }
}
