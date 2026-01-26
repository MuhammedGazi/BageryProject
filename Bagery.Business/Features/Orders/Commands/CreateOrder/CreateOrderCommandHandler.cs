using Bagery.Core.Consts;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IGenericRepository<Order> _orderRepository,
                                           IGenericRepository<Product> _productRepository,
                                           IUnitOfWork _unitOfWork) : IRequestHandler<CreateOrderCommand, IResult>
    {
        public async Task<IResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderStatus = OrderStatus.Hazirlaniyor,
                OrderDetails = new List<OrderDetail>()
            };
            decimal totalAmount = 0;
            foreach (var item in request.BasketItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product != null)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = product.ProductId,
                        UnitPrice = product.Price,
                        Quantity = item.Quantity,
                        OrderId = order.Id
                    };
                    totalAmount += (product.Price * item.Quantity);
                    order.OrderDetails.Add(orderDetail);
                }
            }
            order.TotalPrice = totalAmount;
            await _orderRepository.CreateAsync(order);
            await _unitOfWork.SaveChangeAsync();
            return new SuccessResult("Sipariþ Baþarýyla Oluþturuldu");
        }
    }
}
