using DinnerNet.Domain.Common.Models;
namespace DinnerNet.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{

    private UserId(Guid value) : base(value)
    {

    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

}