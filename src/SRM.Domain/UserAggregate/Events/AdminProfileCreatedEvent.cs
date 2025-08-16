using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.UserAggregate.Events;

public record AdminProfileCreatedEvent(Guid UserId, Guid AdminId) : IDomainEvent;
