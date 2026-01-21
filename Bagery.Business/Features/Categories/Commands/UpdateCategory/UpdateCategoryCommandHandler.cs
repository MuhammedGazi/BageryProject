using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(IGenericRepository<Category> _repository,
                                              IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();
            _repository.Update(category);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.CategoryUpdated) : new ErrorResult(Messages.CategoryUpdatedFailed);
        }
    }
}
