using MediatR;
using Super.Core.Data.EF;
using Super.Core.Data.EF.Extensions;
using Super.Core.DTO;
using Super.Core.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.Data.QueryHandlers.EF
{
    public class FindStoreChainPagedQueryHandler : IRequestHandler<FindStoreChainPagedQuery, IPagedCollection<StoreChain>>
    {
        private readonly DataContext dataContext;

        public FindStoreChainPagedQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IPagedCollection<StoreChain>> Handle(
            FindStoreChainPagedQuery request, 
            CancellationToken cancellationToken)
        {
            var page = await dataContext.StoreChains
                .Select(x => new StoreChain(x.Id, x.Name))
                .OrderBy(x => x.Name)
                .ToPagedCollectionAsync(request.PageParams);

            return page;
        }
    }
}
