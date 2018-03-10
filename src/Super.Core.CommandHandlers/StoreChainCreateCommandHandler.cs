using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class StoreChainCreateCommandHandler : IRequestHandler<StoreChainCreateCommand>
    {
        private readonly IStoreChainRepository storeChain;

        public StoreChainCreateCommandHandler(IStoreChainRepository storeChain)
        {
            this.storeChain = storeChain ?? throw new ArgumentNullException(nameof(storeChain));
        }

        public async Task Handle(StoreChainCreateCommand message, CancellationToken cancellationToken)
        {
            var e = new StoreChain(message.Id, message.Name);
            storeChain.Add(e);
        }
    }
}
