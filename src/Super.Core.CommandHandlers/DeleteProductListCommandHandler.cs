using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class DeleteProductListCommandHandler : IRequestHandler<DeleteProductListCommand>
    {
        private readonly IProductListRepository productLists;

        public DeleteProductListCommandHandler(IProductListRepository productLists)
        {
            this.productLists = productLists ?? throw new ArgumentNullException(nameof(productLists));
        }
        public async Task Handle(DeleteProductListCommand message, CancellationToken cancellationToken)
        {
            productLists.Delete(message.Id);
        }
    }
}
