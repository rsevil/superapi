using Super.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Super.Core.Data.Repositories
{
    public interface IStoreRepository
    {
        void Add(Store store);
        Task<Store> FindById(Guid id);
        void Update(Store e);
    }
}
