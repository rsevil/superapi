using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand>
    {
        private readonly IProductRepository products;

        public ProductCreateCommandHandler(IProductRepository products)
        {
            this.products = products ?? throw new ArgumentNullException(nameof(products));
        }

        public async Task Handle(ProductCreateCommand message, CancellationToken cancellationToken)
        {
            var e = new Product(message.Id, message.Name, message.PhotoUrl);

            products.Add(e);
        }
    }
}
