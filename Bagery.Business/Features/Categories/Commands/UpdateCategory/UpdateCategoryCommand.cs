using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string Name) : IRequest<IResult>;
}
