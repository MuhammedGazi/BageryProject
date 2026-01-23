using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Promotions.Queries.GetPromotionList;

public record GetPromotionListQuery() : IRequest<IDataResult<List<GetPromotionListQueryResult>>>;
