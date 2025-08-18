using ErrorOr;
using SRM.Domain.Common.Enums;
using SRM.Domain.Common.Models;
using SRM.Domain.EmployeeAggregate.Events;

namespace SRM.Domain.EmployeeAggregate;

public class Employee : AggregateRoot
{
	public Guid EmployeeId { get; set; }
	public Hierarchy.Division Division { get; private set; }
	public Hierarchy.Department Department { get; private set; }
	public Hierarchy.Section Section { get; private set; }
	public Hierarchy.Role Role { get; private set; }
	public Guid? DirectManagerId { get; private set; }
	public List<Guid> _requestIds = [];

	private Employee(
		Guid employeeId,
		Hierarchy.Division division,
		Hierarchy.Department department,
		Hierarchy.Section section,
		Hierarchy.Role role,
		Guid? directManagerId = null,
		Guid? id = null)
			: base(id ?? Guid.NewGuid())
	{
		EmployeeId = employeeId;
		Division = division;
		Department = department;
		Section = section;
		Role = role;
		DirectManagerId = directManagerId;
	}

	public static Employee CreateEmployee(
		Guid employeeId,
		Hierarchy.Division division,
		Hierarchy.Department department,
		Hierarchy.Section section,
		Hierarchy.Role role,
		Guid? directManagerId = null,
		Guid? id = null)
	{
		return new Employee(
			employeeId,
			division,
			department,
			section,
			role,
			directManagerId,
			id);
	}

	public Guid CreateRequest(RequestType requestType)
	{
		var requestId = Guid.NewGuid();
		_requestIds.Add(requestId);

		_domainEvents.Add(new RequestCreatedEvent(
			Id, 
			requestId, 
			requestType));

		return requestId;
	}

	public ErrorOr<Success> CancelRequest(Guid requestId)
	{
		if (!_requestIds.Remove(requestId))
		{
			return Error.NotFound("Employee does not own this request.");
		}

		_domainEvents.Add(new RequestCanceledEvent(
			Id, 
			requestId));

		return Result.Success;
	}


}
