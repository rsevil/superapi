using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Commands
{
    public class ProductCreateCommand : IRequest
    {
        public ProductCreateCommand(Guid id, string name, string photoUrl)
        {
            Id = id;
            Name = name;
            PhotoUrl = photoUrl;
        }

        public Guid Id { get; private set; }
        public string Name { get; }
        public string PhotoUrl { get; }
    }
}
