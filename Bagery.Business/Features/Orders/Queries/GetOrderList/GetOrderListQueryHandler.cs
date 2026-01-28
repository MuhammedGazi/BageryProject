using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bagery.Business.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler(IGenericRepository<Order> repository) : IRequestHandler<GetOrderListQuery, IDataResult<List<GetOrderListQueryResult>>>
    {
        public async Task<IDataResult<List<GetOrderListQueryResult>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await repository.GetAllAsync(q => q.Include(x => x.Customer)
                                                            .Include(x => x.OrderDetails)
                                                            .ThenInclude(od => od.Product)
                                                            .ThenInclude(p => p.ProductImages).AsSplitQuery());

            var config = new TypeAdapterConfig();
            config.NewConfig<OrderDetail, OrderDetail>().Ignore(dest => dest.Order);
            config.NewConfig<ProductImage, ProductImage>().Ignore(dest => dest.Product);
            var result = orders.Adapt<List<GetOrderListQueryResult>>(config);

            return new SuccessDataResult<List<GetOrderListQueryResult>>(result, Messages.OrdersListed);
        }
    }
}
