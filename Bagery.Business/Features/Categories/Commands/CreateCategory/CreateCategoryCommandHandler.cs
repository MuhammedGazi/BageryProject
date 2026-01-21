using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(IGenericRepository<Category> repository) : IRequestHandler<CreateCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
