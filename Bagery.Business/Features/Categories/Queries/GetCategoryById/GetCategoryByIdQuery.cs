using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(int Id) : IRequest<IDataResult<GetCategoryByIdQueryResult>>;
