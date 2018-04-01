using MediatR;
using Super.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Queries
{
    public class FindProductListByIdQuery : IRequest<ProductListById>
    {
        public FindProductListByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
