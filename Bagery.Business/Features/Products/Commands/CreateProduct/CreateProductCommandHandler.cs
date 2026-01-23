using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IGenericRepository<Product> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductCommand, IResult>
    {
        public async Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await _repository.CreateAsync(product);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ProductAdded) : new ErrorResult(Messages.ProductAddedFailed);
        }
    }
}
