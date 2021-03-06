﻿using MediatR;
using Super.Core.Data;
using Super.Core.DTO;

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
