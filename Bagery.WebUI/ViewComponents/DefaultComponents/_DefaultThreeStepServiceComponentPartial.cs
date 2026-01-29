using Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultThreeStepServiceComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetThreeStepServiceListQuery());
            return View(result.Data);
        }
    }
}
