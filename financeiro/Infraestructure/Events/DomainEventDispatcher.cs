using financeiro.Application.Contract;
using financeiro.Domain.Common;
using MediatR;

namespace financeiro.Infraestructure.Events;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
        => _mediator = mediator;

    public async Task DispatchAsync(IEnumerable<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
            await _mediator.Publish(domainEvent);
    }
}
