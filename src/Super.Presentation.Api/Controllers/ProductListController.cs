using MediatR;
using Microsoft.AspNetCore.Mvc;
using Super.Core.Commands;
using Super.Core.Queries;
using Super.Presentation.Api.Models.Product;
//using Super.Presentation.Api.Models.ProductList;
using System;
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
        public async Task<IActionResult> Post([FromBody]PostParams postParams)
        {
            var id = Guid.NewGuid();

            await mediator.Send(
                new ProductListCreateCommand(
                    id,
                    postParams.Name,
                    Guid.NewGuid(),//postParams.UserId,
                    null//postParams.ProductIds
                )
            );

            return Ok(id);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(GetParams getParams)
        //{
        //    return Ok(
        //        await mediator.Send(
        //            new FindProductListPagedQuery(getParams.PageParams)));
        //}

        //[HttpGet(nameof(Detail))]
        //public async Task<IActionResult> Detail(GetDetailParams getDetailParams)
        //{
        //    return Ok(
        //        await mediator.Send(
        //            new FindProductByIdQuery(getDetailParams.Id)));
        //}
    }
}
