using DinnerNet.Domain.Common.Models;
using DinnerNet.Domain.DinnerAggregate;
using DinnerNet.Domain.MenuAggregate;
using DinnerNet.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DinnerNet.Infrastructure;

public class DinnerDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventsInterceptor;

    public DinnerDbContext(DbContextOptions<DinnerDbContext> options,
    PublishDomainEventInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;

}