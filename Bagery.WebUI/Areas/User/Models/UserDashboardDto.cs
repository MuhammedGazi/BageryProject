using Bagery.Business.Features.Orders.Queries.GetOrderList;
using Bagery.Business.Features.Products.Queries.GetProductList;

namespace Bagery.WebUI.Areas.User.Models
{
    public class UserDashboardDto
    {
        public int ActiveCount { get; set; }
        public int PromotionCount { get; set; }
        public decimal PaymentCount { get; set; }
        public List<GetOrderListQueryResult> OrderList { get; set; }
        public List<GetProductListQueryResult> ProductList { get; set; }
    }
}
