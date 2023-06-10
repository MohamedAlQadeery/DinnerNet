using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Dinner.ValueObjects;
using DinnerNet.Domain.Guest.ValueObjects;

namespace DinnerNet.Domain.Bill.ValueObjects;

public sealed class BillId : ValueObject
{
    public string Value { get; }


    private BillId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Bill_{dinnerId.Value}_{guestId.Value}";
    }

    private BillId(string value)
    {
        Value = value;
    }


    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new BillId(dinnerId, guestId);
    }

    public static BillId Create(string value)
    {
        return new BillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
