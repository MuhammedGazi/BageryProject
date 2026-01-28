using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IGenericRepository<Order> _repository,
                                           IUnitOfWork _unitOfWork,
                                           ILogger<DeleteOrderCommandHandler> _logger) : IRequestHandler<DeleteOrderCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            if (order is null)
            {
                _logger.LogError(Messages.OrderNotFound, request.Id);
                return new ErrorResult(Messages.OrderNotFound);
            }
            _repository.Delete(order);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.OrderDeleted) : new ErrorResult(Messages.OrderDeletedFailed);
        }
    }
}
