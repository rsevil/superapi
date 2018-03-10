using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class StoreCreateCommandHandler : IRequestHandler<StoreCreateCommand>
    {
        private readonly IStoreRepository store;

        public StoreCreateCommandHandler(IStoreRepository store)
        {
            this.store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task Handle(StoreCreateCommand message, CancellationToken cancellationToken)
        {
            var e = new Store(
                message.Id, message.StoreChainId, message.Name, 
                message.Latitude, message.Longitude, message.Address);

            store.Add(e);
        }
    }
}
