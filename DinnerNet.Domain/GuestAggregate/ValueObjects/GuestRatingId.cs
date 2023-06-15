using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.Models.Identities;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;

namespace DinnerNet.Domain.GuestAggregate.ValueObjects;

public sealed class GuestRatingId : EntityId<string>
{


    private GuestRatingId(HostId hostId, DinnerId dinnerId) : base($"GuestRating_{hostId.Value}_{dinnerId.Value}")
    {

    }

    private GuestRatingId(string value) : base(value)
    {
    }


    public static GuestRatingId Create(HostId hostId, DinnerId dinnerId)
    {
        return new GuestRatingId(hostId, dinnerId);
    }

    public static GuestRatingId Create(string value)
    {
        return new GuestRatingId(value);
    }


}