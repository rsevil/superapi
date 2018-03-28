using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Commands
{
    public class ProductListCreateCommand : IRequest
    {
        public ProductListCreateCommand(Guid id, string name, Guid userId, IEnumerable<Guid> productIds)
        {
            Id = id;
            Name = name;
            UserId = userId;
            ProductIds = productIds;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid UserId { get; }
        public IEnumerable<Guid> ProductIds { get; }
    }
}
