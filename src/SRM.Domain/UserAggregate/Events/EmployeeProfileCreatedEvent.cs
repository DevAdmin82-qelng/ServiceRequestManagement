using SRM.Domain.Common.Interfaces;
using SRM.Domain.Common.Enums;

namespace SRM.Domain.UserAggregate.Events;

public record EmployeeProfileCreatedEvent(
        Guid UserId, 
        Guid EmployeeId, 
        Hierarchy.Role Role, 
        Hierarchy.Division? Division,
        Hierarchy.Department? Department,
        Hierarchy.Section? Section) 
            : IDomainEvent;
