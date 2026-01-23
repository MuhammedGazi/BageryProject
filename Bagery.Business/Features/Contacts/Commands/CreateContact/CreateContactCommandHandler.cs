using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler(IGenericRepository<Contact> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<CreateContactCommand, IResult>
    {
        public async Task<IResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = request.Adapt<Contact>();
            await _repository.CreateAsync(contact);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ContactAdded) : new ErrorResult(Messages.ContactAddedFailed);
        }
    }
}
