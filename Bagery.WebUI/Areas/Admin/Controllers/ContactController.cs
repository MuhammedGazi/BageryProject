using Bagery.Business.Features.Contacts.Commands.CreateContact;
using Bagery.Business.Features.Contacts.Commands.DeleteContact;
using Bagery.Business.Features.Contacts.Commands.UpdateContact;
using Bagery.Business.Features.Contacts.Queries.GetContactById;
using Bagery.Business.Features.Contacts.Queries.GetContactList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetContactListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            var values = await _mediator.Send(command);
            return values.Success ? RedirectToAction(nameof(Index)) : View(values.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _mediator.Send(new DeleteContactCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
