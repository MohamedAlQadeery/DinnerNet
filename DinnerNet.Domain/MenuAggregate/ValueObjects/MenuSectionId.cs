using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.Models.Identities;

namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuSectionId : EntityId<Guid>
{

    private MenuSectionId(Guid value) : base(value)
    {

    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuSectionId(value);
    }

}