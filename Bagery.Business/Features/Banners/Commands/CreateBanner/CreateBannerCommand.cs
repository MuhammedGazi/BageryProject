using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Features.Banners.Commands.CreateBanner
{
    public record CreateBannerCommand(int BannerId, string Title, string Description, IFormFile ImageFile) : IRequest<IResult>;
}
