using Bagery.Business.Features.Promotions.Commands.CreatePromotion;
using Bagery.Business.Features.Promotions.Commands.DeletePromotion;
using Bagery.Business.Features.Promotions.Commands.UpdatePromotion;
using Bagery.Business.Features.Promotions.Queries.GetPromotionById;
using Bagery.Business.Features.Promotions.Queries.GetPromotionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetPromotionListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public IActionResult CreatePromotion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CreatePromotionCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePromotion(int id)
        {
            var value = await _mediator.Send(new GetPromotionByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(UpdatePromotionCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeletePromotion(int id)
        {
            var value = await _mediator.Send(new DeletePromotionCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
