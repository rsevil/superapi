using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Commands
{
    public class StoreChainCreateCommand : IRequest
    {
        public StoreChainCreateCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
