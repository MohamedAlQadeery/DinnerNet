using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;

namespace DinnerNet.Domain.GuestAggregate.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public string Value { get; set; }


    private GuestRatingId(HostId hostId, DinnerId dinnerId)
    {
        Value = $"GuestRating_{hostId.Value}_{dinnerId.Value}";
    }

    private GuestRatingId(string value)
    {
        Value = value;
    }


    public static GuestRatingId Create(HostId hostId, DinnerId dinnerId)
    {
        return new GuestRatingId(hostId, dinnerId);
    }

    public static GuestRatingId Create(string value)
    {
        return new GuestRatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}