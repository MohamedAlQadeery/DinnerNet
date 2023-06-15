using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.Common.Models.Identities;

namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuItemId : EntityId<Guid>
{

    private MenuItemId(Guid value) : base(value)
    {

    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }


}