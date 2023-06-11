using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Dinner.ValueObjects;
using DinnerNet.Domain.Guest.ValueObjects;
using DinnerNet.Domain.Menu.ValueObjects;

namespace DinnerNet.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public string Value { get; }


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