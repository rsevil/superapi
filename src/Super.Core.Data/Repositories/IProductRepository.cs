using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
    }
}
