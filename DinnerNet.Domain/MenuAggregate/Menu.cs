using System.Collections.Generic;
using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.Entities;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using DinnerNet.Domain.MenuReviewAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviews = new();

    public string Name { get; private set; }
    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public HostId HostId { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> Reviews => _reviews.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }



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
        List<MenuSection>? sections = null)
    {
        // TODO: enforce invariants
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new());
    }

    public void AddDinnerId(DinnerId dinnerId)
    {
        _dinnerIds.Add(dinnerId);
    }


#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618

}