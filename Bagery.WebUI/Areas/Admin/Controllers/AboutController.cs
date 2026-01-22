using Bagery.Business.Features.Abouts.Commands.CreateAbout;
using Bagery.Business.Features.Abouts.Commands.DeleteAbout;
using Bagery.Business.Features.Abouts.Commands.UpdateAbout;
using Bagery.Business.Features.Abouts.Queries.GetAboutById;
using Bagery.Business.Features.Abouts.Queries.GetAboutList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAboutListQuery());
            return values.Success ? View(values.Data) : View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            var values = await _mediator.Send(command);
            return values.Success ? RedirectToAction(nameof(Index)) : View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(id));
            return values.Success ? View(values.Data) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            var values = await _mediator.Send(command);
            return values.Success ? RedirectToAction(nameof(Index)) : View();
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var values = await _mediator.Send(new DeleteAboutCommand(id));
            return values.Success ? RedirectToAction(nameof(Index)) : View();
        }
    }

}
