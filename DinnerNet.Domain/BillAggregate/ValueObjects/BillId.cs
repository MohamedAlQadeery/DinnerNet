using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;

namespace DinnerNet.Domain.BillAggregate.ValueObjects;

public sealed class BillId : AggregateRootId<string>
{


    private BillId(DinnerId dinnerId, GuestId guestId) : base($"Bill_{dinnerId.Value}_{guestId.Value}")
    {

    }

    private BillId(string value) : base(value)
    {

    }


    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new BillId(dinnerId, guestId);
    }

    public static BillId Create(string value)
    {
        return new BillId(value);
    }


}
