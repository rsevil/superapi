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
    public class FindProductPagedQueryHandler : IRequestHandler<FindProductPagedQuery, IPagedCollection<Product>>
    {
        private readonly DataContext dataContext;

        public FindProductPagedQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IPagedCollection<Product>> Handle(FindProductPagedQuery request, CancellationToken cancellationToken)
        {
            var page = await dataContext.Products
                .Select(x => new Product(x.Id, x.Name, x.PhotoUrl))
                .OrderBy(x => x.Name)
                .ToPagedCollectionAsync(request.PageParams);

            return page;
        }
    }
}
