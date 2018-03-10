using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.Data.EF.MediatR
{
    public class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly DataContext dataContext;

        public TransactionalBehavior(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            if (request.GetType().Name.EndsWith("Query"))
                return await next();

            var response = await next();
            await dataContext.SaveChangesAsync();
            return response;
        }
    }
}
