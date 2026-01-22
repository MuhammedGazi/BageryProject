using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Abouts.Commands.UpdateAbout
{
    public record UpdateAboutCommand(int AboutId, string MainTitle, string AboutTitle, string AboutDescription, string OverviewTitle, string OverviewDescription, string Overview1, string Overview2, string Overview3, string MainImageUrl) : IRequest<IResult>;
}
