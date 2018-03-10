using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.DTO
{
    public class StoreByChain
    {
        public StoreByChain(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }
    }
}
