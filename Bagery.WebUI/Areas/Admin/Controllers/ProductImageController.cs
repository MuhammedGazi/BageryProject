using Bagery.Business.Features.ProductImages.Commands.CreateProductImage;
using Bagery.Business.Features.ProductImages.Commands.DeleteProductImage;
using Bagery.Business.Features.ProductImages.Commands.UpdateProductImage;
using Bagery.Business.Features.ProductImages.Queries.GetProductImageById;
using Bagery.Business.Features.ProductImages.Queries.GetProductImageList;
using Bagery.Business.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductImageController(IMediator _mediator) : Controller
    {
        private async Task GetProductAsync()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            ViewBag.Products = (from product in products.Data
                                select new SelectListItem
                                {
                                    Text = product.Name,
                                    Value = product.ProductId.ToString()
                                }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetProductImageListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            await GetProductAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(int id)
        {
            await GetProductAsync();
            var value = await _mediator.Send(new GetProductImageByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var value = await _mediator.Send(new DeleteProductImageCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
