using DinnerNet.Domain.BillAggregate.ValueObjects;
using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate.Enums;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;

namespace DinnerNet.Domain.DinnerAggregate.Entites;

public sealed class Reservation : AggregateRoot<ReservationId>
{
    public DinnerId DinnerId { get; }

    public int GuestCount { get; }
    public DateTime ReservationDateTime { get; }
    public ReservationStatus Status { get; }

    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        DateTime? arrivalDateTime,
        BillId? billId,
        ReservationStatus status)
        : base(ReservationId.Create(dinnerId, guestId))
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        BillId = billId;
        Status = status;
    }

    public static Reservation Create(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        ReservationStatus status,
        BillId? billId = null,
        DateTime? arrivalDateTime = null)
    {
        // TODO: Enforce invariants
        return new Reservation(
            dinnerId,
            guestId,
            guestCount,
            arrivalDateTime,
            billId,
            status);
    }

}