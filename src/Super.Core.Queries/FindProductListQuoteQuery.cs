using MediatR;
using Super.Core.Data;
using Super.Core.DTO;
using System;

namespace Super.Core.Queries
{
    public class FindProductListQuoteQuery : IRequest<IPagedCollection<ProductListQuote>>
    {
        public FindProductListQuoteQuery(Guid productListId, decimal latitude, decimal longitude, IPageParams pageParams)
        {
            ProductListId = productListId;
            Latitude = latitude;
            Longitude = longitude;
            PageParams = pageParams ?? throw new ArgumentNullException(nameof(pageParams));
        }

        public Guid ProductListId { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public IPageParams PageParams { get; }
    }
}
