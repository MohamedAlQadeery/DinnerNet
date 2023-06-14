using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }

    public string Description { get; private set; }


    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }


#pragma warning disable CS8618

    private MenuItem()
    {
    }

#pragma warning restore CS8618       
}