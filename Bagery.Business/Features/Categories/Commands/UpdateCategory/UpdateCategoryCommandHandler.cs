using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(IGenericRepository<Category> repository) : IRequestHandler<UpdateCategoryCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
