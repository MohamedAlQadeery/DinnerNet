using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.UserAggregate.ValueObjects;

namespace DinnerNet.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    public HostId(UserId userId)
    {
        Value = $"Host_{userId.Value}";
    }

    public HostId(string userId)
    {
        Value = userId;
    }

    public static HostId Create(UserId userId)
    {
        return new HostId(userId);
    }

    public static HostId Create(string userId)
    {
        return new HostId(userId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}