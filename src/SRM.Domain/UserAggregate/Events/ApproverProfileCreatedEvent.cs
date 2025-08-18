using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.UserAggregate.Events;

public record ApproverProfileCreatedEvent(
        Guid UserId, 
        Guid ManagerId) 
            : IDomainEvent;
