using Bagery.Business.Features.Orders.Commands.UpdateOrder;
using Bagery.Business.Features.Orders.Queries.GetOrderList;
using Bagery.Core.Consts;
using Bagery.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class OrderController(IMediator mediator, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await mediator.Send(new GetOrderListQuery());
            var value = result.Data.Where(x => x.CustomerId == user.Id).ToList();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await mediator.Send(new UpdateOrderCommand(id, OrderStatus.IptalEdildi));
            return RedirectToAction(nameof(Index));
        }
    }
}
