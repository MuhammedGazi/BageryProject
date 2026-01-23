using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Promotions.Commands.UpdatePromotion
{
    public class UpdatePromotionCommandHandler(IGenericRepository<Promotion> _repository,
                                               IUnitOfWork _unitOfWork) : IRequestHandler<UpdatePromotionCommand, IResult>
    {
        public async Task<IResult> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = request.Adapt<Promotion>();
            _repository.Update(promotion);
            var value = await _unitOfWork.SaveChangeAsync();
            return value ? new SuccessResult(Messages.PromotionUpdated) : new ErrorResult(Messages.PromotionUpdatedFailed);
        }
    }
}
