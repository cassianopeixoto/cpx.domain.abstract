namespace CPX.Domain.Abstract.Events;

public interface IApplyDomainEvent<TDomainEvent> where TDomainEvent : DomainEvent
{
    void Apply(TDomainEvent @event);
}