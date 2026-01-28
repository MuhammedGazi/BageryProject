using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Banners.Commands.UpdateBanner
{
    public record UpdateBannerCommand(int BannerId, string Title, string Description, string? ImageUrl, string? ImagePublicId) : IRequest<IResult>;
}
