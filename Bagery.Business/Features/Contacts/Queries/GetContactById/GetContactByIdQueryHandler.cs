using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Contacts.Queries.GetContactById
{
    public class GetContactByIdQueryHandler(IGenericRepository<Contact> _repository,
                                            ILogger<GetContactByIdQueryHandler> _logger) : IRequestHandler<GetContactByIdQuery, IDataResult<GetContactByIdQueryResult>>
    {
        public async Task<IDataResult<GetContactByIdQueryResult>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                _logger.LogError(Messages.ContactNotFound, request.Id);
                return new ErrorDataResult<GetContactByIdQueryResult>(Messages.ContactNotFound);
            }
            var result = contact.Adapt<GetContactByIdQueryResult>();
            return new SuccessDataResult<GetContactByIdQueryResult>(result, Messages.ContactListed);
        }
    }
}
