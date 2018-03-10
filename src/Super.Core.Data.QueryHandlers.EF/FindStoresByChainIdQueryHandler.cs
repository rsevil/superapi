using MediatR;
using Super.Core.Data.EF;
using Super.Core.Data.EF.Extensions;
using Super.Core.DTO;
using Super.Core.Queries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.Data.QueryHandlers.EF
{
    public class FindStoresByChainIdQueryHandler : IRequestHandler<FindStoresByChainIdQuery, IPagedCollection<StoreByChain>>
    {
        private readonly DataContext dataContext;

        public FindStoresByChainIdQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IPagedCollection<StoreByChain>> Handle(
            FindStoresByChainIdQuery request, 
            CancellationToken cancellationToken)
        {
            return await dataContext.Stores
                .Where(x => x.StoreChainId == request.ChainId)
                .Select(x => new StoreByChain(x.Id, x.Name, x.Address))
                .OrderBy(x => x.Name)
                .ToPagedCollectionAsync(request.PageParams);
        }
    }
}
