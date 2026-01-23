using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Contacts.Queries.GetContactList
{
    public class GetContactListQueryHandler(IGenericRepository<Contact> _repository) : IRequestHandler<GetContactListQuery, IDataResult<List<GetContactListQueryResult>>>
    {
        public async Task<IDataResult<List<GetContactListQueryResult>>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAllAsync();
            var result = contact.Adapt<List<GetContactListQueryResult>>();
            return new SuccessDataResult<List<GetContactListQueryResult>>(result, Messages.ContactsListed);
        }
    }
}
