using DinnerNet.Domain.Common.Models;
using ErrorOr;

namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuId : AggregateRootId<Guid>
{

    private MenuId(Guid value) : base(value)
    {

    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuId(value);
    }

    public static ErrorOr<MenuId> Create(string value)
    {
        if (!Guid.TryParse(value, out var guid))
        {
            return Common.Errors.Errors.Menu.InvalidMenuId;
        }

        return new MenuId(guid);
    }

}