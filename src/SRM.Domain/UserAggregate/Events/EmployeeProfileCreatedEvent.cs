using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.UserAggregate.Events;

public record EmployeeProfileCreatedEvent(Guid UserId, Guid EmployeeId) : IDomainEvent;
