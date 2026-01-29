using Bagery.Business.Features.ProductImages.Queries.GetProductImageList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.ViewComponents.DefaultComponents
{
    public class _DefaultGalleryComponentPartial(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gallery = await _mediator.Send(new GetProductImageListQuery());
            return View(gallery.Data);
        }
    }
}
