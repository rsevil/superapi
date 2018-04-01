using MediatR;
using System;

namespace Super.Core.Commands
{
    public class DeleteProductListCommand : IRequest
    {
        public DeleteProductListCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
