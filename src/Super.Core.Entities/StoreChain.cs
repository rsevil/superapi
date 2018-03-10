using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class StoreChain
    {
        private StoreChain() { }

        public StoreChain(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Store> Stores { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
