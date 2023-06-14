using DinnerNet.Domain.Common.Models;
namespace DinnerNet.Domain.MenuAggregate.ValueObjects;


public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
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
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}