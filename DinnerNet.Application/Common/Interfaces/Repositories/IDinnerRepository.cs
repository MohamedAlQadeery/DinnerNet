using DinnerNet.Domain.DinnerAggregate;
using DinnerNet.Domain.HostAggregate.ValueObjects;

public interface IDinnerRepository
{
    Task AddAsync(Dinner dinner);
    Task<List<Dinner>> ListAsync(HostId hostId);
}