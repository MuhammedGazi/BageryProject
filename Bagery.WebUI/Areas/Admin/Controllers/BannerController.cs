using Bagery.Business.Features.Banners.Commands.CreateBanner;
using Bagery.Business.Features.Banners.Commands.DeleteBanner;
using Bagery.Business.Features.Banners.Commands.UpdateBanner;
using Bagery.Business.Features.Banners.Queries.GetBannerById;
using Bagery.Business.Features.Banners.Queries.GetBannerList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BannerController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetBannerListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _mediator.Send(new GetBannerByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            var value = await _mediator.Send(new DeleteBannerCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }
}
