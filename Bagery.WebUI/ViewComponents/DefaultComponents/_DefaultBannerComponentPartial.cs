using Bagery.Business.Features.Banners.Queries.GetBannerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultBannerComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banner = await _mediator.Send(new GetBannerListQuery());
            return banner.Success ? View(banner.Data) : View();
        }
    }
}
