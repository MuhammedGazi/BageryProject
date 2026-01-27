using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Features.Abouts.Commands.CreateAbout
{
    public record CreateAboutCommand(int AboutId, string MainTitle, string AboutTitle, string AboutDescription, string OverviewTitle, string OverviewDescription, string Overview1, string Overview2, string Overview3, IFormFile ImageFile) : IRequest<IResult>;
}
