using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string PhotoUrl { get; private set; }
    }
}
