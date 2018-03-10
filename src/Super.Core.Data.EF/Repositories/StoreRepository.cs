using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;

namespace Super.Core.Data.EF.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext dataContext;

        public StoreRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Add(Store store)
        {
            dataContext.Add(store);
        }
    }
}
