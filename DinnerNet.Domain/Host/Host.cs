using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.Dinner.ValueObjects;
using DinnerNet.Domain.Host.ValueObjects;
using DinnerNet.Domain.Menu.ValueObjects;
using DinnerNet.Domain.User.ValueObjects;

namespace DinnerNet.Domain.Host;

public class Host : AggregateRoot<HostId>
{

    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage { get; }
    public AverageRating AverageRating { get; }

    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
          HostId hostId,
          string firstName,
          string lastName,
          Uri profileImage,
          UserId userId,
          AverageRating averageRating)
          : base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId)
    {
        // TODO: enforce invariants
        return new Host(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            userId,
            AverageRating.CreateNew());
    }


}