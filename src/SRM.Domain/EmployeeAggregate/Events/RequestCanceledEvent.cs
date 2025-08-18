
using SRM.Domain.Common.Interfaces;

namespace SRM.Domain.EmployeeAggregate.Events;

public record RequestCanceledEvent(
	Guid Id, 
	Guid RequestId) 
		: IDomainEvent; 