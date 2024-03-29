

using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using DinnerNet.Domain.MenuReviewAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId, string>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }

    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
        : base(menuReviewId)
    {

        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        MenuReviewId? menuReviewId = null)
    {
        // TODO: enforce invariants
        var ratingValueObject = Rating.Create(rating);

        return new MenuReview(
            menuReviewId ?? MenuReviewId.Create(menuId, dinnerId, guestId),
            ratingValueObject,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId);
    }
}