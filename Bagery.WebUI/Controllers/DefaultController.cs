using Bagery.Business.Features.Contacts.Commands.CreateContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Controllers
{
    public class DefaultController(IMediator _mediator) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction("Index");
            }
            return View(command);
        }
    }
}
