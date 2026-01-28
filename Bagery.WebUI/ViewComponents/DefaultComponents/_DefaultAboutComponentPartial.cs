using Bagery.Business.Features.Abouts.Queries.GetAboutList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _mediator.Send(new GetAboutListQuery());
            return View(about.Data);
        }
    }
}
