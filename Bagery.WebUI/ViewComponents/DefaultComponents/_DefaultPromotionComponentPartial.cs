using Bagery.Business.Features.Promotions.Queries.GetPromotionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultPromotionComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetPromotionListQuery());
            return View(result.Data);
        }
    }
}
