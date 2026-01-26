using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutPreloaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
