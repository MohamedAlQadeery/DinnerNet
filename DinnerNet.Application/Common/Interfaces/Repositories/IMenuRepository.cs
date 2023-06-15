using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate;
using DinnerNet.Domain.MenuAggregate.ValueObjects;

namespace DinnerNet.Application.Common.Interfaces.Repositories;

public interface IMenuRepository
{
    Task UpdateAsync(Menu menu);

    void CreateMenu(Menu menu);
    Task<Menu?> GetByIdAsync(MenuId menuId);
    Task<bool> ExistsAsync(MenuId menuId);
    Task<List<Menu>> ListAsync(HostId hostId);
}