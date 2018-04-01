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
    public class FindProductListByIdQueryHandler : IRequestHandler<FindProductListByIdQuery, ProductListById>
    {
        private readonly DataContext dataContext;

        public FindProductListByIdQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<ProductListById> Handle(FindProductListByIdQuery request, CancellationToken cancellationToken)
        {
            return await dataContext.ProductLists
                .Where(x => x.Id == request.Id)
                .Select(x => 
                    new ProductListById(
                        x.Id, 
                        x.Name, 
                        x.ProductListProducts
                            .Select(y => 
                                new ProductListById.Product(
                                    y.ProductId, 
                                    y.Product.Name, 
                                    y.Product.PhotoUrl,
                                    y.Quantity))))
                .SingleOrDefaultAsync();
        }
    }
}
