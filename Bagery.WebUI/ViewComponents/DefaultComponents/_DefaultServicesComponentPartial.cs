using Bagery.Business.Features.Services.Queries.GetServiceList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultServicesComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetServiceListQuery());
            return View(result.Data);
        }
    }
}
