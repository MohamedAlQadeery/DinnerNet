using DinnerNet.Domain.Common.Models.Identities;

namespace DinnerNet.Domain.Common.Models;

public abstract class AggregateRootId<TId> : EntityId<TId>
{
    protected AggregateRootId(TId value) : base(value)
    {
    }


}