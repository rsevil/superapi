using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Core.Data.Repositories
{
    public interface IStoreChainRepository
    {
        Task<StoreChain> FindByIdAsync(Guid id);

        void Add(StoreChain storeChain);

        void Update(StoreChain storeChain);
    }
}
