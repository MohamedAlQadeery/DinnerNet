using DinnerNet.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace DinnerNet.Infrastructure;

public class DinnerDbContext : DbContext
{
    public DinnerDbContext(DbContextOptions<DinnerDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Menu> Menus { get; set; } = null!;
}