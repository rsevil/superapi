using MediatR;
using Super.Core.Commands;
using Super.Core.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.CommandHandlers
{
    public class StoreUpdateCommandHandler : IRequestHandler<StoreUpdateCommand>
    {
        private readonly IStoreRepository store;

        public StoreUpdateCommandHandler(IStoreRepository store)
        {
            this.store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task Handle(StoreUpdateCommand message, CancellationToken cancellationToken)
        {
            var e = await store.FindById(message.Id);

            e.Update(message.Name, message.Latitude, message.Longitude, message.Address);

            store.Update(e);
        }
    }
}