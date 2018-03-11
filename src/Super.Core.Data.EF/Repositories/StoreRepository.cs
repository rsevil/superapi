using Microsoft.EntityFrameworkCore;
using Super.Core.Data.Repositories;
using Super.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Store> FindById(Guid id)
        {
            return await dataContext.Stores.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public void Update(Store e)
        {
            dataContext.Update(e);
        }
    }
}
