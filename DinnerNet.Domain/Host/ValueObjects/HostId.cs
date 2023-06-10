using DinnerNet.Domain.Common.Models;

namespace DinnerNet.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }


    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}