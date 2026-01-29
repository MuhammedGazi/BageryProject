using Bagery.Core.Entities;
using Bagery.DataAccess.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bagery.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class PromotionController(AppDbContext _context, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user is not null)
            {
                var notifications = await _context.Notifications.Where(x => x.AppUserId == user.Id && !x.IsRead)
                                                                .OrderByDescending(x => x.CreatedDate)
                                                                .Take(5)
                                                                .ToListAsync();
                return View(notifications);
            }
            return View(new List<Notification>());
        }
    }
}
