using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionCommandHandler(IGenericRepository<Promotion> _repository,
                                               ILogger<DeletePromotionCommandHandler> _logger,
                                               IUnitOfWork _unitOfWork) : IRequestHandler<DeletePromotionCommand, IResult>
    {
        public async Task<IResult> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _repository.GetByIdAsync(request.Id);
            if (promotion == null)
            {
                _logger.LogError(Messages.PromotionNotFound, request.Id);
                return new ErrorResult(Messages.PromotionNotFound);
            }
            _repository.Delete(promotion);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.PromotionDeleted) : new ErrorResult(Messages.PromotionDeletedFailed);
        }
    }
}
