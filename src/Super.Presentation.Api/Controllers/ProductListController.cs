using MediatR;
using Microsoft.AspNetCore.Mvc;
using Super.Core.Commands;
using Super.Core.Queries;
using Super.Presentation.Api.Models.ProductList;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductListController : Controller
    {
        private readonly IMediator mediator;

        public ProductListController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody]ProductListPostParams productListPostParams)
        {
            var id = Guid.NewGuid();

            await mediator.Send(
                new ProductListCreateCommand(
                    id,
                    productListPostParams.Name,
                    productListPostParams.UserId,
                    productListPostParams.Products
                        .Select(x => new ProductListCreateCommand.Product(x.Id, x.Quantity))
                )
            );

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetParams getParams)
        {
            return Ok(
                await mediator.Send(
                    new FindProductListPagedQuery(getParams.PageParams)));
        }

        [HttpGet(nameof(Detail))]
        public async Task<IActionResult> Detail(GetDetailParams getDetailParams)
        {
            return Ok(
                await mediator.Send(
                    new FindProductListByIdQuery(getDetailParams.Id)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteParams deleteParams)
        {
            await mediator.Send(new DeleteProductListCommand(deleteParams.Id));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(
            [FromBody]ProductListPutParams productListPutParams)
        {
            await mediator.Send(
                new ProductListUpdateCommand(
                    productListPutParams.Id,
                    productListPutParams.Name,
                    productListPutParams.UserId,
                    productListPutParams.Products
                        .Select(x => new ProductListUpdateCommand.Product(x.Id, x.Quantity))));

            return Ok();
        }
    }
}
