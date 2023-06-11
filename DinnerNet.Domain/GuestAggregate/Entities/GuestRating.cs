using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;

namespace DinnerNet.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{

    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }


    private GuestRating(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating) : base(GuestRatingId.Create(hostId, dinnerId))
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
    }


    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating)
    {
        var ratingValueObject = Rating.Create(rating);

        return new GuestRating(
            hostId,
            dinnerId,
            ratingValueObject);
    }
}