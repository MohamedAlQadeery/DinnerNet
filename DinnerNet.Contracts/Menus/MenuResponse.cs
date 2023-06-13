namespace DinnerNet.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSection> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewsIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime

);