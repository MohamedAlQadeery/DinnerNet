using DinnerNet.Domain.Common.Models;
namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId(Guid value)
    {
        Value = value;
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
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}