namespace Bagery.Business.Features.Abouts.Queries.GetAboutById;

public record GetAboutByIdQueryResult(int AboutId, string MainTitle, string AboutTitle, string AboutDescription, string OverviewTitle, string OverviewDescription, string Overview1, string Overview2, string Overview3, string MainImageUrl);
