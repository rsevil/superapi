using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Models.ProductList
{
    public class ProductListPostParams
    {
        public string Name { get; set; }

        public IEnumerable<Guid> ProductIds { get; set; }

        public string UserId { get; set; }
    }
}
