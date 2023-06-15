using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.DinnerAggregate.Entites;
using DinnerNet.Domain.DinnerAggregate.Enums;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }

    public int MaxGuests { get; private set; }

    public Price Price { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public Location Location { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }
    public Uri ImageUrl { get; private set; }


    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();


    private Dinner(
       DinnerId dinnerId,
       string name,
       string description,
       DateTime startDateTime,
       DateTime endDateTime,
       bool isPublic,
       int maxGuests,
       Price price,
       MenuId menuId,
       HostId hostId,
       Uri imageUrl,
       Location location)
       : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        MenuId = menuId;
        HostId = hostId;
        ImageUrl = imageUrl;
        Location = location;
        Status = DinnerStatus.Upcoming;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        MenuId menuId,
        HostId hostId,
        Uri imageUrl,
        Location location)
    {
        // enforce invariants
        var dinner = new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            menuId,
            hostId,
            imageUrl,
            location);


        return dinner;
    }

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618
}