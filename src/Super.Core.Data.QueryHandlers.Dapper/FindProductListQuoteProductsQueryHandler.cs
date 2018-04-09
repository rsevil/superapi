using Dapper;
using MediatR;
using Super.Core.DTO;
using Super.Core.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Super.Core.Data.QueryHandlers.Dapper
{
    public class FindProductListQuoteProductsQueryHandler : IRequestHandler<FindProductListQuoteProductsQuery, IEnumerable<ProductListQuoteProduct>>
    {
        private readonly IDbConnection dbConnection;

        public FindProductListQuoteProductsQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IEnumerable<ProductListQuoteProduct>> Handle(
            FindProductListQuoteProductsQuery request, 
            CancellationToken cancellationToken)
        {
            var query = @"
                SELECT 
                    p.Id, 
                    p.Name, 
                    pr.Amount,
                    plp.Quantity
                FROM ProductListProduct plp
                JOIN Prices pr on pr.ProductId = plp.ProductId 
                JOIN Products p on p.Id = pr.ProductId
                WHERE 
	                plp.ProductListId = @ProductListId AND 
	                pr.StoreId = @StoreId";

            var filters = new
            {
                request.ProductListId,
                request.StoreId
            };

            var data = await dbConnection
                .QueryAsync<ProductListQuoteProduct>(query, filters);

            return data.AsList();
        }
    }
}
