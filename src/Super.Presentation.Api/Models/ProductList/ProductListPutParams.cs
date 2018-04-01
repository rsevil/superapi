using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Models.ProductList
{
    public class ProductListPutParams : ProductListPostParams
    {
        public Guid Id { get; set; }
    }
}
