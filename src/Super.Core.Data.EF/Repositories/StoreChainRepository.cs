using Microsoft.EntityFrameworkCore;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.Core.Data.EF.Repositories
{
    public class StoreChainRepository : IStoreChainRepository
    {
        private readonly DataContext dataContext;

        public StoreChainRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<StoreChain> FindByIdAsync(Guid id)
        {
            return await dataContext.StoreChains
                .SingleAsync(x => x.Id == id);
        }

        public void Add(StoreChain storeChain)
        {
            dataContext.Add(storeChain);
        }

        public void Update(StoreChain storeChain)
        {
            dataContext.Update(storeChain);
        }
    }
}
