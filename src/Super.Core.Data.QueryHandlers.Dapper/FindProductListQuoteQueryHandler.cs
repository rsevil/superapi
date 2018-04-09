using MediatR;
using Super.Core.DTO;
using Super.Core.Queries;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace Super.Core.Data.QueryHandlers.Dapper
{
    public class FindProductListQuoteQueryHandler 
        : IRequestHandler<FindProductListQuoteQuery, IPagedCollection<ProductListQuote>>
    {
        private readonly IDbConnection dbConnection;

        public FindProductListQuoteQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IPagedCollection<ProductListQuote>> Handle(
            FindProductListQuoteQuery request,
            CancellationToken cancellationToken)
        {
            var query = $@"
                DECLARE @Origin Geography
                SET @Origin = Geography::Point(@{nameof(request.Latitude)}, @{nameof(request.Longitude)}, 4326)
                SELECT COUNT(1)
                FROM (
	                SELECT
		                StoreId = s.Id,
		                StoreName = s.Name,
		                s.Address,
                        s.Latitude, 
		                s.Longitude,
		                Amount = SUM(plp.Quantity * p.Amount),
		                Distance = @Origin.STDistance(Geography::Point(s.Latitude, s.Longitude, 4326))
	                FROM ProductLists pl
	                JOIN ProductListProduct plp on plp.ProductListId = pl.Id
	                JOIN Prices p on p.ProductId = plp.ProductId
	                JOIN Stores s on s.Id = p.StoreId
                    WHERE pl.Id = @{nameof(request.ProductListId)}
	                GROUP BY s.Id, s.Name, s.Address, s.Latitude, s.Longitude
                ) as t
                SELECT 
	                t.*,
	                Score = t.Amount * 0.7 + t.Distance * 0.3
                FROM (
	                SELECT
		                StoreId = s.Id,
		                StoreName = s.Name,
		                Address = s.Address,
		                Amount = SUM(p.Amount),
		                Distance = @Origin.STDistance(Geography::Point(s.Latitude, s.Longitude, 4326))
	                FROM ProductLists pl
	                JOIN ProductListProduct plp on plp.ProductListId = pl.Id
	                JOIN Prices p on p.ProductId = plp.ProductId
	                JOIN Stores s on s.Id = p.StoreId
                    WHERE pl.Id = @{nameof(request.ProductListId)}
	                GROUP BY s.Id, s.Name, s.Address, s.Latitude, s.Longitude
                ) as t
                ORDER BY Score ASC
                OFFSET {request.PageParams.StartIndex} ROWS FETCH NEXT {request.PageParams.Length} ROWS ONLY";

            var @params = new
            {
                request.ProductListId,
                request.Latitude,
                request.Longitude
            };

            using (var dataResult = await dbConnection.QueryMultipleAsync(query, @params))
            {
                var totalRecords = await dataResult.ReadSingleAsync<int>();
                var data = await dataResult.ReadAsync<ProductListQuote>();

                return new PagedCollection<ProductListQuote>(
                    data, totalRecords, request.PageParams.GetCurrentPage());
            }
        }
    }
}
