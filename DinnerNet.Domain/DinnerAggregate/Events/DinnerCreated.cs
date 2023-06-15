using DinnerNet.Domain.Common.Models;

namespace DinnerNet.Domain.DinnerAggregate.Events;
public record DinnerCreated(Dinner Dinner) : IDomainEvent;