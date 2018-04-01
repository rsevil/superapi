using System;

namespace Super.Core.DTO
{
    public class ProductList
    {
        public ProductList(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
