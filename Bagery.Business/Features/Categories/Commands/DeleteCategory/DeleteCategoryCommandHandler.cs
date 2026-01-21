using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(IGenericRepository<Category> repository) : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
