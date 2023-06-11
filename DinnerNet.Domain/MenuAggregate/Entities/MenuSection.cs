using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();


    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();


    private MenuSection(string name, string description, List<MenuItem> items, MenuSectionId? id = null)
        : base(id ?? MenuSectionId.CreateUnique())
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name,
     string description, List<MenuItem>? items = null)
    {
        return new MenuSection(name,
                               description,
                               items ?? new(),
                               MenuSectionId.CreateUnique());
    }

}