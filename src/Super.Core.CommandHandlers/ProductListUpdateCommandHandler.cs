using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class ProductListUpdateCommandHandler : IRequestHandler<ProductListUpdateCommand>
    {
        private readonly IProductListRepository productListRepository;

        public ProductListUpdateCommandHandler(IProductListRepository productListRepository)
        {
            this.productListRepository = productListRepository ?? throw new ArgumentNullException(nameof(productListRepository));
        }
        public async Task Handle(ProductListUpdateCommand message, CancellationToken cancellationToken)
        {
            var productList = await productListRepository.Find(message.Id);

            var products = message.Products
                .Select(product =>
                {
                    // caso que no existe, estoy agregando uno
                    if (!productList.ProductListProducts.Any(x => x.ProductId == product.Id))
                    {
                        var item = new ProductListProduct(message.Id, product.Id, product.Quantity);
                        productListRepository.AddProductListProduct(item);
                        return item;
                    }
                    else if (productList.ProductListProducts.Any(x => x.ProductId == product.Id))
                    {
                        var item = new ProductListProduct(message.Id, product.Id, product.Quantity);
                        return item;
                    }

                    return null;
                }).ToList();

            productList.Update(message.Name, products);

            productListRepository.Update(productList);
        }
    }
}
