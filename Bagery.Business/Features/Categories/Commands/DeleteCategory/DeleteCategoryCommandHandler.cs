using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(IGenericRepository<Category> _repository,
                                              IUnitOfWork _unitOfWork) : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            _repository.Delete(category);
            return await _unitOfWork.SaveChangeAsync()
                ? new SuccessResult(Messages.CategoryDeleted)
                : new ErrorResult(Messages.CategoryDeletedFailed);
        }
    }
}
