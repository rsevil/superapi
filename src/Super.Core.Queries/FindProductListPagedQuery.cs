using MediatR;
using Super.Core.Data;
using Super.Core.DTO;

namespace Super.Core.Queries
{
    public class FindProductListPagedQuery : IRequest<IPagedCollection<ProductList>>
    {
        public FindProductListPagedQuery(IPageParams pageParams)
        {
            PageParams = pageParams;
        }

        public IPageParams PageParams { get; }
    }
}
