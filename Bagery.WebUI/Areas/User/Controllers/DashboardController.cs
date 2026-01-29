using Bagery.Business.Features.Orders.Queries.GetOrderList;
using Bagery.Business.Features.Products.Queries.GetProductList;
using Bagery.Core.Consts;
using Bagery.Core.Entities;
using Bagery.DataAccess.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bagery.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController(AppDbContext _appDbContext, UserManager<AppUser> _userManager, IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            UserDashboardDto dto = new UserDashboardDto();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.ActiveCount = await _appDbContext.Orders.Where(x => x.CustomerId == user.Id && x.OrderStatus != OrderStatus.IptalEdildi).CountAsync();
            dto.PromotionCount = await _appDbContext.Promotions.CountAsync();
            dto.PaymentCount = await _appDbContext.Orders.Where(x => x.CustomerId == user.Id).SumAsync(x => x.TotalPrice);
            var result1 = await _mediator.Send(new GetOrderListQuery());
            dto.OrderList = result1.Data.Where(x => x.CustomerId == user.Id).ToList();
            var reselt2 = await _mediator.Send(new GetProductListQuery());
            dto.ProductList = reselt2.Data;
            return View(dto);
        }
    }

    public class UserDashboardDto
    {
        public int ActiveCount { get; set; }
        public int PromotionCount { get; set; }
        public decimal PaymentCount { get; set; }
        public List<GetOrderListQueryResult> OrderList { get; set; }
        public List<GetProductListQueryResult> ProductList { get; set; }
    }
}
