using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class Store
    {
        public Store(Guid id, Guid storeChainId, string name, decimal latitude, decimal longitude, string address)
        {
            Id = id;
            StoreChainId = storeChainId;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }

        public Guid Id { get; private set; }

        public Guid StoreChainId { get; private set; }

        public string Name { get; private set; }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }

        public string Address { get; private set; }
    }
}
