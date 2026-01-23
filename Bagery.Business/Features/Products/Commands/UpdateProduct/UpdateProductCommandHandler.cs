using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IGenericRepository<Product> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<UpdateProductCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            _repository.Update(product);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ProductUpdated) : new ErrorResult(Messages.ProductUpdatedFailed);
        }
    }
}
