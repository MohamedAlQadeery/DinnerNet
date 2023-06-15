using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.UserAggregate.ValueObjects;

namespace DinnerNet.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{

    public HostId(UserId userId) : base($"Host_{userId.Value}")
    {

    }

    public HostId(string userId) : base(userId)
    {
    }

    public static HostId Create(UserId userId)
    {
        return new HostId(userId);
    }

    public static HostId Create(string userId)
    {
        return new HostId(userId);
    }


}