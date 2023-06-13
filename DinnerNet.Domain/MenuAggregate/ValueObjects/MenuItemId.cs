using DinnerNet.Domain.Common.Models;
namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}