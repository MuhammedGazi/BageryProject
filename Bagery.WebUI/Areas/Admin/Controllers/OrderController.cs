using Bagery.Business.Features.Orders.Commands.DeleteOrder;
using Bagery.Business.Features.Orders.Commands.UpdateOrder;
using Bagery.Business.Features.Orders.Queries.GetOrderList;
using Bagery.Core.Consts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var orders = await _mediator.Send(new GetOrderListQuery());
            return orders.Success ? View(orders.Data) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int orderId, OrderStatus status)
        {
            var orders = await _mediator.Send(new UpdateOrderCommand(orderId, status));
            return orders.Success ? RedirectToAction(nameof(Index)) : View();
        }

        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var result= await _mediator.Send(new DeleteOrderCommand(orderId));
            return result.Success ? RedirectToAction(nameof(Index)) : View();
        }
    }
}
