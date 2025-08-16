using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.UserAggregate.Events;

public record SupportProfileCreatedEvent(Guid UserId, Guid SupportId) : IDomainEvent;
