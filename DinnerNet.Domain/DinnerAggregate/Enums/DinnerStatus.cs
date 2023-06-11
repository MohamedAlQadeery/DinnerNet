using Ardalis.SmartEnum;

namespace DinnerNet.Domain.DinnerAggregate.Enums;

public sealed class DinnerStatus : SmartEnum<DinnerStatus>
{

    public DinnerStatus(string name, int value) : base(name, value)
    {

    }

    public static readonly DinnerStatus Upcoming = new(nameof(Upcoming), 1);
    public static readonly DinnerStatus InProgress = new(nameof(InProgress), 2);
    public static readonly DinnerStatus Ended = new(nameof(Ended), 3);
    public static readonly DinnerStatus Cancelled = new(nameof(Cancelled), 4);

}