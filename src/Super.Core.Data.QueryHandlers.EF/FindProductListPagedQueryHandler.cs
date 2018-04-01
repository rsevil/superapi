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
    public class FindProductListPagedQueryHandler : IRequestHandler<FindProductListPagedQuery, IPagedCollection<ProductList>>
    {
        private readonly DataContext dataContext;

        public FindProductListPagedQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IPagedCollection<ProductList>> Handle(
            FindProductListPagedQuery request, 
            CancellationToken cancellationToken)
        {
            var page = await dataContext.ProductLists
                .Select(x => new ProductList(x.Id, x.Name))
                .OrderBy(x => x.Name)
                .ToPagedCollectionAsync(request.PageParams);

            return page;
        }
    }
}
