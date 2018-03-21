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
    public class FindProductByIdQueryHandler : IRequestHandler<FindProductByIdQuery, ProductById>
    {
        private readonly DataContext dataContext;

        public FindProductByIdQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<ProductById> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await dataContext.Products
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductById(x.Id, x.Name, x.PhotoUrl))
                .SingleAsync();
        }
    }
}
