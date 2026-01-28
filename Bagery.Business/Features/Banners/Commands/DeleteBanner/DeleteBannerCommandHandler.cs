using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Banners.Commands.DeleteBanner
{
    public class DeleteBannerCommandHandler(IGenericRepository<Banner> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ILogger<DeleteBannerCommandHandler> _logger,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<DeleteBannerCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
