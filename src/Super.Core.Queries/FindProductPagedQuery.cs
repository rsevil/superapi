using MediatR;
using Super.Core.Data;
using Super.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Queries
{
    public class FindProductPagedQuery : IRequest<IPagedCollection<Product>>
    {
        public FindProductPagedQuery(IPageParams pageParams)
        {
            PageParams = pageParams;
        }

        public IPageParams PageParams { get; }
    }
}
