using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.UserAggregate.ValueObjects;

namespace DinnerNet.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<string>
{

    public GuestId(UserId userId) : base($"Guest_{userId.Value}")
    {
    }

    public GuestId(string userId) : base(userId)
    {
    }

    public static GuestId Create(UserId userId)
    {
        return new GuestId(userId);
    }

    public static GuestId Create(string userId)
    {
        return new GuestId(userId);
    }


}
