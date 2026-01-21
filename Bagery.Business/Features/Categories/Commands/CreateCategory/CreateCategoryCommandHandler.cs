using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(IGenericRepository<Category> _repository,
                                              IUnitOfWork _unitOfWork) : IRequestHandler<CreateCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();
            await _repository.CreateAsync(category);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.CategoryAdded) : new ErrorResult(Messages.CategoryAddedFailed);
        }
    }
}
