using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Banners.Commands.DeleteBanner
{
    public record DeleteBannerCommand(int Id) : IRequest<IResult>;
}
