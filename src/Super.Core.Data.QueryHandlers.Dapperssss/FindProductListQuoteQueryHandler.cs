using MediatR;
using System;

namespace Super.Core.Data.QueryHandlers.Dapper
{
    public class FindProductListQuoteQueryHandler : IRequestHandler<FindProductListQuoteQuery, IPagedCollection<ProductListQuote>>
    {
        //private readonly DataContext dataContext;

        public FindProductListQuoteQueryHandler()
        {
            //this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IPagedCollection<ProductListQuote>> Handle(
            FindProductListQuoteQuery request,
            CancellationToken cancellationToken)
        {
            //dataContext
            //    .ProductLists.Where()

            return new PagedCollection<ProductListQuote>(Enumerable.Empty<ProductListQuote>(), 0, 0);
        }
    }
}
