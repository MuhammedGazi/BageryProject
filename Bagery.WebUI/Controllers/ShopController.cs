using Bagery.Business.DTOs.OrderDTOs;
using Bagery.Business.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bagery.WebUI.Controllers
{
    public class ShopController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var product = await _mediator.Send(new GetProductListQuery());
            return product.Success ? View(product.Data) : View();
        }

        public IActionResult AddToCart(int id, string name, decimal price)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<OrderItemDto> cart = cartJson == null
                ? new List<OrderItemDto>()
                : JsonSerializer.Deserialize<List<OrderItemDto>>(cartJson);

            var existingItem = cart.FirstOrDefault(x => x.ProductId == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new OrderItemDto { ProductId = id, Name = name, Price = price, Quantity = 1 });
            }

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

            return RedirectToAction("Index");
        }

        public IActionResult ShopBasket()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<OrderItemDto> cart = cartJson == null
            ? new List<OrderItemDto>()
            : JsonSerializer.Deserialize<List<OrderItemDto>>(cartJson);

            return View(cart);
        }
    }
}
