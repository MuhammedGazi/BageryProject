using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Promotions.Commands.CreatePromotion
{
    public class CreatePromotionCommandHandler(IGenericRepository<Promotion> _repository,
                                               IUnitOfWork _unitOfWork) : IRequestHandler<CreatePromotionCommand, IResult>
    {
        public async Task<IResult> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = request.Adapt<Promotion>();
            await _repository.CreateAsync(promotion);
            var value = await _unitOfWork.SaveChangeAsync();
            return value ? new SuccessResult(Messages.PromotionAdded) : new ErrorResult(Messages.PromotionAddedFailed);
        }
    }
}
