using Bagery.Business.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultOurShopComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetProductListQuery());
            return View(result.Data);
        }
    }
}
