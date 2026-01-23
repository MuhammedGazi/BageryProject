using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IGenericRepository<Product> _repository,
                                             IUnitOfWork _unitOfWork,
                                             ILogger<DeleteProductCommandHandler> _logger) : IRequestHandler<DeleteProductCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product is null)
            {
                _logger.LogError(Messages.ProductNotFound, request.Id);
                return new ErrorResult(Messages.ProductNotFound);
            }
            _repository.Delete(product);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ProductDeleted) : new ErrorResult(Messages.ProductDeletedFailed);
        }
    }
}
