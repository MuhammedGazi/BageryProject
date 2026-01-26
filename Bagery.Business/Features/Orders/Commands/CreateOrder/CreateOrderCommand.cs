using Bagery.Business.DTOs.OrderDTOs;
using Bagery.Business.Features.Products.Queries.GetProductList;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(int CustomerId, List<OrderItemDto> BasketItems) : IRequest<IResult>;
