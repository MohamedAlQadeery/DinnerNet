using DinnerNet.Domain.Common.Models;

namespace DinnerNet.Domain.DinnerAggregate.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    private Location(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }


    public static Location Create(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new Location(name, address, latitude, longitude);
    }




    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }



#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    private Location() { }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
