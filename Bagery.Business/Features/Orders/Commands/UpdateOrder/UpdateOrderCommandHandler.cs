using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler(IGenericRepository<Order> _repository,
                                           IUnitOfWork _unitOfWork,
                                           ILogger<UpdateOrderCommandHandler> _logger) : IRequestHandler<UpdateOrderCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            order.OrderStatus = request.OrderStatus;
            _repository.Update(order);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.OrderUpdated) : new ErrorResult(Messages.OrderUpdatedFailed);
        }
    }
}
