using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<string>
{
    public override string Value { get; protected set; }


    private MenuReviewId(MenuId menuId, DinnerId dinnerId, GuestId guestId)
    {
        Value = $"MenuReview_{menuId.Value}_{dinnerId.Value}_{guestId.Value}";
    }

    private MenuReviewId(string value)
    {
        Value = value;
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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}