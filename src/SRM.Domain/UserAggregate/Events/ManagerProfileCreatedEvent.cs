using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.UserAggregate.Events;

public record ManagerProfileCreatedEvent(Guid UserId, Guid ManagerId) : IDomainEvent;
