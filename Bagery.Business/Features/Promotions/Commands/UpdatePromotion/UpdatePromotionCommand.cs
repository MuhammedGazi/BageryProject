using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Promotions.Commands.UpdatePromotion;

public record UpdatePromotionCommand(int PromotionId, string IconUrl, decimal Price, string Title, string Description) : IRequest<IResult>;
