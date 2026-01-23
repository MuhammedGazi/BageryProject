using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Promotions.Queries.GetPromotionById;

public record GetPromotionByIdQuery(int Id) : IRequest<IDataResult<GetPromotionByIdQueryResult>>;
