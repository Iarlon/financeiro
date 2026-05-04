using financeiro.Domain.Common;

namespace financeiro.Application.Contract;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> events);
}
