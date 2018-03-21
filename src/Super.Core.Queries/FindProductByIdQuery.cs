using MediatR;
using Super.Core.DTO;
using System;

namespace Super.Core.Queries
{
    public class FindProductByIdQuery : IRequest<ProductById>
    {
        public FindProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
