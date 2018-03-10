using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class StoreChainUpdateCommandHandler : IRequestHandler<StoreChainUpdateCommand>
    {
        private readonly IStoreChainRepository storeChain;

        public StoreChainUpdateCommandHandler(IStoreChainRepository storeChain)
        {
            this.storeChain = storeChain ?? throw new ArgumentNullException(nameof(storeChain));
        }

        public async Task Handle(StoreChainUpdateCommand message, CancellationToken cancellationToken)
        {
            var e = await storeChain.FindByIdAsync(message.Id);

            e.ChangeName(message.Name);

            storeChain.Update(e);
        }
    }
}
