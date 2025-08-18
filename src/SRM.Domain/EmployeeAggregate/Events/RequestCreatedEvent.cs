
using SRM.Domain.Common.Enums;
using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.EmployeeAggregate.Events;

public record RequestCreatedEvent(
	Guid Id,
	Guid RequestId, 
	RequestType RequestType)
		: IDomainEvent;