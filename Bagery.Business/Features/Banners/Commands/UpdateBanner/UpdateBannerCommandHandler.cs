using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandHandler(IGenericRepository<Banner> repository) : IRequestHandler<UpdateBannerCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
