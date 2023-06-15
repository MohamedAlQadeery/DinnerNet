using DinnerNet.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DinnerNet.Infrastructure.Interceptors;

public class PublishDomainEventInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publisher;
    public PublishDomainEventInterceptor(IPublisher publisher)
    {
        _publisher = publisher;

    }


    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(DbContext? dbContext)
    {
        if (dbContext is null) { return; }
        //get all entites that has domain event
        var entitesWithDomainEvents = dbContext.ChangeTracker
        .Entries<IHasDomainEvents>()
        .Select(x => x.Entity)
        .ToList();

        //get all domain events from entites
        var domainEvents = entitesWithDomainEvents.SelectMany(x => x.DomainEvents).ToList();

        //clear domain events from entites
        entitesWithDomainEvents.ForEach(x => x.ClearDomainEvents());

        //publish domain events
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}