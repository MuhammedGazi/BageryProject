using Bagery.Business.Features.Services.Commands.CreateService;
using Bagery.Business.Features.Services.Commands.DeleteService;
using Bagery.Business.Features.Services.Commands.UpdateService;
using Bagery.Business.Features.Services.Queries.GetServiceById;
using Bagery.Business.Features.Services.Queries.GetServiceList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetServiceListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var value = await _mediator.Send(new DeleteServiceCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
