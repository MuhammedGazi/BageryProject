using Bagery.Business.Features.ThreeStepServices.Commands.CreateThreeStepService;
using Bagery.Business.Features.ThreeStepServices.Commands.DeleteThreeStepService;
using Bagery.Business.Features.ThreeStepServices.Commands.UpdateThreeStepService;
using Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceById;
using Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ThreeStepServiceController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _mediator.Send(new GetThreeStepServiceListQuery());
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpGet]
        public IActionResult CreateThreeStepService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateThreeStepService(CreateThreeStepServiceCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateThreeStepService(int id)
        {
            var value = await _mediator.Send(new GetThreeStepServiceByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateThreeStepService(UpdateThreeStepServiceCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteThreeStepService(int id)
        {
            var value = await _mediator.Send(new DeleteThreeStepServiceCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
