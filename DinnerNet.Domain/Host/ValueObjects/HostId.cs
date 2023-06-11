using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.User.ValueObjects;

namespace DinnerNet.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; }

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