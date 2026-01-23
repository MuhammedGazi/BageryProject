using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler(IGenericRepository<Contact> repository,
                                             IUnitOfWork _unitOfWork,
                                             ILogger<DeleteContactCommandHandler> _logger) : IRequestHandler<DeleteContactCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await repository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                _logger.LogError(Messages.ContactDeletedFailed, request.Id);
                return new ErrorResult(Messages.ContactNotFound);
            }
            repository.Delete(contact);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ContactDeleted) : new ErrorResult(Messages.ContactDeletedFailed);
        }
    }
}
