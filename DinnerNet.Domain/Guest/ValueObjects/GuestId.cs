using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.User.ValueObjects;

namespace DinnerNet.Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    public string Value { get; }

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
