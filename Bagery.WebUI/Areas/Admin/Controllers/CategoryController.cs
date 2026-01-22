using Bagery.Business.Features.Categories.Commands.CreateCategory;
using Bagery.Business.Features.Categories.Commands.DeleteCategory;
using Bagery.Business.Features.Categories.Commands.UpdateCategory;
using Bagery.Business.Features.Categories.Queries.GetCategoryById;
using Bagery.Business.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController(IMediator _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.Send(new GetCategoryListQuery());
            return values.Success ? View(values.Data) : throw new Exception(values.Message);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var value = await _service.Send(command);
            return value.Success ? RedirectToAction(nameof(Index)) : View(command);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _service.Send(new GetCategoryByIdQuery(id));
            return value.Success ? View(value.Data) : throw new Exception(value.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _service.Send(command);
            return result.Success ? RedirectToAction(nameof(Index)) : throw new Exception(result.Message);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _service.Send(new DeleteCategoryCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }

}
