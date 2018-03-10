using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.DTO
{
    public class Store
    {
        public Store(string name, decimal latitude, decimal longitude, string address)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }

        public string Name { get; private set; }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }

        public string Address { get; private set; }
    }
}
