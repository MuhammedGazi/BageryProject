using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler(IGenericRepository<Contact> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<UpdateContactCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = request.Adapt<Contact>();
            _repository.Update(contact);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ContactUpdated) : new ErrorResult(Messages.ContactUpdatedFailed);
        }
    }
}
