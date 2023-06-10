using System.Collections.Generic;
using DinnerNet.Domain.Common.Models;
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

    public double AverageRating { get; }

    public HostId HostId { get; set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> Reviews => _reviews.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    private Menu(
        MenuId menuId,
        string name,
        string description,
        double averageRating,
        List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
    }


    public static Menu Create(
        string name,
        string description,
        double averageRating,
        List<MenuSection>? sections = null)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            sections ?? new()
        );
    }


}