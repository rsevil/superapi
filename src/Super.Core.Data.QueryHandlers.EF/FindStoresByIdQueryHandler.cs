using MediatR;
using Microsoft.EntityFrameworkCore;
using Super.Core.Data.EF;
using Super.Core.DTO;
using Super.Core.Queries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.Data.QueryHandlers.EF
{
    public class FindStoresByIdQueryHandler : IRequestHandler<FindStoresByIdQuery, Store>
    {
        private readonly DataContext dataContext;

        public FindStoresByIdQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<Store> Handle(FindStoresByIdQuery request, CancellationToken cancellationToken)
        {
            return await dataContext.Stores
                .Where(x => x.Id == request.Id)
                .Select(x => new Store(x.Name, x.Latitude, x.Longitude, x.Address))
                .SingleAsync();
        }
    }
}
