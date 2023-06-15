using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DinnerNet.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DinnerDbContext _dbContext;

    public MenuRepository(DinnerDbContext context)
    {
        _dbContext = context;

    }
    public void CreateMenu(Menu menu)
    {
        _dbContext.Menus.Add(menu);
        _dbContext.SaveChanges();
    }

    public async Task<bool> ExistsAsync(MenuId menuId)
    {
        return await _dbContext.Menus.AnyAsync(menu => menu.Id == menuId);
    }

    public async Task<Menu?> GetByIdAsync(MenuId menuId)
    {
        return await _dbContext.Menus.FirstOrDefaultAsync(menu => menu.Id == menuId);
    }

    public async Task<List<Menu>> ListAsync(HostId hostId)
    {
        return await _dbContext.Menus.Where(menu => menu.HostId == hostId).ToListAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _dbContext.Menus.Update(menu);
        await _dbContext.SaveChangesAsync();
    }
}
