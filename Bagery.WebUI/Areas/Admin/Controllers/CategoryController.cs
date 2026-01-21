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

        //[HttpPost]
        //public async Task<IActionResult> CreateCategory( dto)
        //{
        //    await _service.TCreateAsync(dto);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _service.Send(new GetCategoryByIdQuery(id));
            return value.Success ? View(value.Data) : throw new Exception(value.Message);
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        //{
        //    await _service.TUpdateAsync(dto);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    await _service.TDeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }

}
