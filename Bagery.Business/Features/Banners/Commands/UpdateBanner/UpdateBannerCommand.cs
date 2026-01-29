using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Features.Banners.Commands.UpdateBanner
{
    public record UpdateBannerCommand(int BannerId, string Title, string Description, IFormFile? Image) : IRequest<IResult>;
}
