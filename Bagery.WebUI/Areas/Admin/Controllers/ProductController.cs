using Bagery.Business.Features.Categories.Queries.GetCategoryList;
using Bagery.Business.Features.Products.Commands.CreateProduct;
using Bagery.Business.Features.Products.Commands.DeleteProduct;
using Bagery.Business.Features.Products.Commands.UpdateProduct;
using Bagery.Business.Features.Products.Queries.GetProductById;
using Bagery.Business.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bagery.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController(IMediator _mediator) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());
            ViewBag.Categories = (from category in categories.Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetProductListQuery());
            return values.Success ? View(values.Data) : View(values.Message);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var value = await _mediator.Send(new GetProductByIdQuery(id));
            return value.Success ? View(value.Data) : View(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var value = await _mediator.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _mediator.Send(new DeleteProductCommand(id));
            return value.Success ? RedirectToAction(nameof(Index)) : View(value.Message);
        }
    }

}
