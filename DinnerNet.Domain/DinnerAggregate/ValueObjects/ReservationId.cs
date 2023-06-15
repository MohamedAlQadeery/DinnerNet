using DinnerNet.Domain.BillAggregate.ValueObjects;
using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.Models.Identities;
using DinnerNet.Domain.GuestAggregate.ValueObjects;

namespace DinnerNet.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : EntityId<Guid>
{


    private ReservationId(Guid value) : base(value)
    {
    }


    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }
}