using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Commands
{
    public class StoreUpdateCommand : IRequest
    {
        public StoreUpdateCommand(Guid id, string name, decimal latitude, decimal longitude, string address)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public string Address { get; }
    }
}
