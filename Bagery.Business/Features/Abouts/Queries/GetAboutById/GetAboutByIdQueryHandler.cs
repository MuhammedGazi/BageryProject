using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Abouts.Queries.GetAboutById
{
    public class GetAboutByIdQueryHandler(IGenericRepository<About> repository,
                                          ILogger<GetAboutByIdQueryHandler> _logger) : IRequestHandler<GetAboutByIdQuery, IDataResult<GetAboutByIdQueryResult>>
    {
        public async Task<IDataResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var about = await repository.GetByIdAsync(request.Id);
            if (about is null)
            {
                _logger.LogError(Messages.AboutNotFound, request.Id);
                return new ErrorDataResult<GetAboutByIdQueryResult>(Messages.AboutNotFound);
            }
            var result = about.Adapt<GetAboutByIdQueryResult>();
            return new SuccessDataResult<GetAboutByIdQueryResult>(result, Messages.AboutListed);
        }
    }
}
