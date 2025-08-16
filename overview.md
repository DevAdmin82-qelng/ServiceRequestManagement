# Overview
## Service Request Management

### Ubiquitous language

User Management:
- A user can create an employee profile.
- A user can create a manager profile.
- An admin can create admin profile for a user.
- An admin can create a support profile for a user.
- An admin can remove a user.
- An admin can update a user from employee -> manager.
- An admin can update a user from manager -> employee.
- An admin can update a user from nonadmin -> admin.
- An admin can update a user from nonsupport -> support.
- An admin/support can update any profile -> approver.
- An admin/support can update any profile -> nonapprover.
- A manager is an approver by default.

Request Management:
- A employee/manager can create a request.
- A employee/manager can cancel their request.
- A employee/manager can update their request.
- An admin/support can cancel any request.
- An admin/support can update any request.
- A request has statues -> Opened, Approvals, In-Progress, Closed.

Request Type Mangement:
- A request has types -> Access, Equipment, Leave, Training, etc.
- An admin can add/update/delete request types.

Approval Management
- A request type has a defined list of Approvers to progress.
- Any employee or manager can be an approver.
- An approver will have access to a dashboard with all active/unactive requests that need their approval.
- An approver can approve/consult/reject a request at their step with an optional message.


Entities:
- User
- Admin
- Support
- Employee
- Manager
- Request
- RequestType

User Aggregate:
- User
    - Properties
        - UserId
        - Name
        - EmailAddress (ValueObject)
        - DirectManagerId (Required)
        - AdminId (Null by default)
        - SupportId (Null by default)
        - EmployeeId (Null by default)
        - ManagerId  (Null by default)
    - Methods
        - CreateAdminProfile
        - CreateSupportProfile
        - CreateEmployeeProfile
        - CreateManagerProfile
        - UpdateDirectManager(managerId: UserId)

- Admin
    - Properties
        - AdminId
    - Methods
        - CreateSupportProfileForUser(userId)
        - CreateAdminProfileForUser(userId)
        - RemoveUser(userId)
        - PromoteEmployeeToManager(userId)
        - DemoteManagerToEmployee(userId)
        - GrantApprover(userId)
        - RevokeApprover(userId)

- Support
    - Properties
        - SupportId
    - Methods
        - GrantApprover(userId)
        - RevokeApprover(userId)

