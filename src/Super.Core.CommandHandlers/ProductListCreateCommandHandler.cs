using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class ProductListCreateCommandHandler : IRequestHandler<ProductListCreateCommand>
    {
        private readonly IProductListRepository productLists;

        public ProductListCreateCommandHandler(
            IProductListRepository productLists)
        {
            this.productLists = productLists ?? throw new ArgumentNullException(nameof(productLists));
        }

        public async Task Handle(ProductListCreateCommand message, CancellationToken cancellationToken)
        {
            var products = message.Products
                .Select(product =>
                {
                    var item = new ProductListProduct(message.Id, product.Id, product.Quantity);
                    productLists.AddProductListProduct(item);
                    return item;
                })
                .ToList();

            var productList = new ProductList(message.Id, message.Name, message.UserId, products);

            productLists.Add(productList);
        }
    }
}
