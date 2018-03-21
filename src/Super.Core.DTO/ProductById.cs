using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.DTO
{
    public class ProductById
    {
        public ProductById(Guid id, string name, string photoUrl)
        {
            Id = id;
            Name = name;
            PhotoUrl = photoUrl;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string PhotoUrl { get; private set; }
    }
}
