using Bagery.Business.DTOs.OrderDTOs;
using Bagery.Business.Features.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bagery.WebUI.Controllers
{
    public class PaymentController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<OrderItemDto> cart = cartJson == null
            ? new List<OrderItemDto>()
            : JsonSerializer.Deserialize<List<OrderItemDto>>(cartJson);

            CreateOrderCommand command = new CreateOrderCommand(1, cart);

            var result = await _mediator.Send(command);
            return RedirectToAction("Index", "Shop");
        }
    }
}
