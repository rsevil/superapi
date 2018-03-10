using MediatR;
using Super.Core.Data;
using Super.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Queries
{
    public class FindStoresByChainIdQuery : IRequest<IPagedCollection<StoreByChain>>
    {
        public FindStoresByChainIdQuery(Guid chainId, IPageParams pageParams)
        {
            ChainId = chainId;
            PageParams = pageParams;
        }

        public Guid ChainId { get; }
        public IPageParams PageParams { get; }
    }
}
