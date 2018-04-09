using MediatR;
using Super.Core.DTO;
using System;
using System.Collections.Generic;

namespace Super.Core.Queries
{
    public class FindProductListQuoteProductsQuery : IRequest<IEnumerable<ProductListQuoteProduct>>
    {
        public FindProductListQuoteProductsQuery(Guid id, Guid storeId)
        {
            ProductListId = id;
            StoreId = storeId;
        }

        public Guid ProductListId { get; private set; }

        public Guid StoreId { get; private set; }
    }
}
