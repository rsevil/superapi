using MediatR;
using Super.Core.Data;
using Super.Core.DTO;
using System;

namespace Super.Core.Queries
{
    public class FindStoreChainPagedQuery : IRequest<IPagedCollection<StoreChain>>
    {
        public FindStoreChainPagedQuery(IPageParams pageParams)
        {
            PageParams = pageParams;
        }

        public IPageParams PageParams { get; }
    }
}
