using System.Collections.Generic;
using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.Dinner.ValueObjects;
using DinnerNet.Domain.Host.ValueObjects;
using DinnerNet.Domain.Menu.Entities;
using DinnerNet.Domain.Menu.ValueObjects;
using DinnerNet.Domain.MenuReview.ValueObjects;

namespace DinnerNet.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviews = new();

    public string Name { get; }
    public string Description { get; }

    public AverageRating AverageRating { get; }

    public HostId HostId { get; set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> Reviews => _reviews.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    private Menu(
        MenuId id,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections) : base(id)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection>? sections = null)
    {
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            averageRating,
            sections ?? new()
        );
    }


}