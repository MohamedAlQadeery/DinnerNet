using DinnerNet.Domain.DinnerAggregate;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DinnerNet.Infrastructure.Repositories;
public class DinnerRepository : IDinnerRepository
{
    private readonly DinnerDbContext _dbContext;

    public DinnerRepository(DinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Dinner dinner)
    {
        await _dbContext.AddAsync(dinner);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Dinner>> ListAsync(HostId hostId)
    {
        return await _dbContext.Dinners.Where(dinner => dinner.HostId == hostId).ToListAsync();
    }
}