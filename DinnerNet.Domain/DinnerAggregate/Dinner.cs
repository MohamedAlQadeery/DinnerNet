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
    public string Name { get; }
    public string Description { get; }

    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }

    public DinnerStatus Status { get; }
    public bool IsPublic { get; }

    public int MaxGuests { get; }

    public Price Price { get; }

    public HostId HostId { get; }

    public MenuId MenuId { get; }

    public Location Location { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }
    public Uri ImageUrl { get; }


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
        return new Dinner(
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
    }
}