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
    public Guid? AdminId { get; private set; }
    public Guid? SupportId { get; private set; }
    public Guid? EmployeeId { get; private set; }
    public Guid? ManagerId { get; private set; } 

    private readonly string _passwordHash = null!;
    
    private User(
        string firstName,
        string lastName,
        EmailAddress emailAddress,
        string passwordHash,
        Guid? adminId = null,
        Guid? supportId = null,
        Guid? employeeId = null,
        Guid? managerId = null,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AdminId = adminId;
        SupportId = supportId;
        EmployeeId = employeeId;
        ManagerId = managerId;
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

       return new User(firstName, lastName, emailResult.Value, passwordHash, id: id);
    }
    
    public bool IsCorrectPasswordHash(
            string password, 
            IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }

    public ErrorOr<Guid> CreateAdminProfile()
    {
        if (AdminId is not null)
        {
            return Error.Conflict(
                    code: "User.Conflict", 
                    description: "User already has an admin profile");
        }

        AdminId = Guid.NewGuid();

        _domainEvents.Add(new AdminProfileCreatedEvent(Id, AdminId.Value));

        return AdminId.Value;
    }

    public ErrorOr<Guid> CreateSupportProfile()
    {
        if (SupportId is not null)
        {
            return Error.Conflict(
                    code: "User.Conflict", 
                    description: "User already has an support profile");
        }

        SupportId = Guid.NewGuid();

        _domainEvents.Add(new SupportProfileCreatedEvent(Id, SupportId.Value));

        return SupportId.Value;
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

    public ErrorOr<Guid> CreateManagerProfile()
    {
        if (ManagerId is not null)
        {
            return Error.Conflict(
                    code: "User.Conflict", 
                    description : "User already has an manager profile");
        }

        ManagerId = Guid.NewGuid();

        _domainEvents.Add(new ManagerProfileCreatedEvent(Id, ManagerId.Value));

        return ManagerId.Value;
    }
}
