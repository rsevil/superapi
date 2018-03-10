using System;

namespace Super.Core.DTO
{
    public class StoreChain
    {
        public StoreChain(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
