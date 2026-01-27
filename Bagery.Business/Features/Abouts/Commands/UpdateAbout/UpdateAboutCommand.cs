using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Features.Abouts.Commands.UpdateAbout
{
    public record UpdateAboutCommand(int AboutId, string MainTitle, string AboutTitle, string AboutDescription, string OverviewTitle, string OverviewDescription, string Overview1, string Overview2, string Overview3, IFormFile? Image) : IRequest<IResult>;
}
