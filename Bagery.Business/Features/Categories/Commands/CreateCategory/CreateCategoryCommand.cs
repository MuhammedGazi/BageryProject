using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name) : IRequest<IResult>;
}
