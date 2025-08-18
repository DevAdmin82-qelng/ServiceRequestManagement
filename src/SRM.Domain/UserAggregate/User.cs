using SRM.Domain.Common.Models;
using SRM.Domain.Common.Interfaces;
using SRM.Domain.Common.Enums;
using SRM.Domain.UserAggregate.Events;
using ErrorOr;

namespace SRM.Domain.UserAggregate;

public class User : AggregateRoot
{
    public string FirstName { get; }
    public string LastName { get; }
    public EmailAddress EmailAddress { get; }
    public Guid? EmployeeId { get; private set; }
    public Guid? ApproverId { get; private set; }

    private readonly string _passwordHash = null!;
    
    private User(
        string firstName,
        string lastName,
        EmailAddress emailAddress,
        string passwordHash,
        Guid? employeeId = null,
        Guid? approverId = null,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        EmployeeId = employeeId;
        ApproverId = approverId;
        _passwordHash = passwordHash;
    }
#nullable disable
    private User() {} // For EF Core mapping.

    public static ErrorOr<User> CreateUser(
        string firstName,
        string lastName,
        string emailAddress,
        string passwordHash,
        Guid? id = null)
    {
       var emailResult = EmailAddress.CreateEmailAddress(emailAddress);
       if (emailResult.IsError)
       {
           return emailResult.Errors;
       }

       return new User(firstName, lastName, emailResult.Value, passwordHash, id);
    }
    
    public bool IsCorrectPasswordHash(
            string password, 
            IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }

    public ErrorOr<Guid> CreateEmployeeProfile(
            Hierarchy.Role role,
            Hierarchy.Division? division = null, 
            Hierarchy.Department? department = null, 
            Hierarchy.Section? section = null)
    {
        if (EmployeeId is not null)
        {
            return Error.Conflict(
                    code: "User.Conflict", 
                    description: "User already has an employee profile");
        }

        EmployeeId = Guid.NewGuid();

        _domainEvents.Add(new EmployeeProfileCreatedEvent(
                    Id, 
                    EmployeeId.Value, 
                    role, 
                    division, 
                    department, 
                    section));

        return EmployeeId.Value;
    }

    public ErrorOr<Guid> CreateApproverProfile()
    {
        if (ApproverId is not null)
        {
            return Error.Conflict(
                    code: "User.Conflict", 
                    description : "User already has an approver profile profile");
        }

        ApproverId = Guid.NewGuid();

        _domainEvents.Add(new ApproverProfileCreatedEvent(Id, ApproverId.Value));

        return ApproverId.Value;
    }
}
