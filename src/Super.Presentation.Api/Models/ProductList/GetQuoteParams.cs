using Super.Core.Queries;
using Super.Presentation.Api.Models.Shared;
using System;

namespace Super.Presentation.Api.Models.ProductList
{
    public class GetQuoteParams
    {
        public Guid ProductListId { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public PageParams PageParams { get; set; }
    }
}
