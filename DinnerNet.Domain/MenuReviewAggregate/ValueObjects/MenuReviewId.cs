using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<string>
{


    private MenuReviewId(MenuId menuId, DinnerId dinnerId, GuestId guestId) :
     base($"MenuReview_{menuId.Value}_{dinnerId.Value}_{guestId.Value}")
    {

    }

    private MenuReviewId(string value) : base(value)
    {

    }

    public static MenuReviewId Create(MenuId menuId, DinnerId dinnerId, GuestId guestId)
    {
        // TODO: enforce invariants
        return new MenuReviewId(menuId, dinnerId, guestId);
    }

    public static MenuReviewId Create(string value)
    {
        // TODO: enforce invariants
        return new MenuReviewId(value);
    }


}