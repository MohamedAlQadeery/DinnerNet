using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.UserAggregate.ValueObjects;

namespace DinnerNet.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    public GuestId(UserId userId)
    {
        Value = $"Guest_{userId.Value}";
    }

    public GuestId(string userId)
    {
        Value = userId;
    }

    public static GuestId Create(UserId userId)
    {
        return new GuestId(userId);
    }

    public static GuestId Create(string userId)
    {
        return new GuestId(userId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
