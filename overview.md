# Overview
## Service Request Management

### Ubiquitous language

User Management:
- A user can create an employee profile
- a user can be an approver (Admin request required)
- A user can be removed (Admin request required)

Request Management:
- A employee can create a request.
- A employee/admin/support can cancel their request.
- A employee/admin/support can update their request.
- A request has statues -> Opened, Approvals, In-Progress, Closed.
- A request has an Actioner to complete and close the request.

Request Type Mangement:
- A request has types -> Access, Equipment, Leave, Training, etc.
- Info required to submit a request is specific to the request type.
- An admin can add/update/delete request types.
- A request type has a defined list of Approvers to progress.

Approval Management
- An approver will have access to a dashboard with all active/unactive requests that need their approval.
- An approver can approve/consult/reject a request at their step with an optional message.
- On approval, the request will be passed to the next appover in the chain. 
  - If at end of chain will be passed to Actioner.
  - Apon completion of action, Request will be marked as Success and closed.
- On rejection, at any approval step/ Actioner step the ticket will be marked as Rejected and closed.
- On Consult, a message and an Employee is required which a notification will be sent to them to consult on the request.
- Comments can be left at any point of the approval/actioner steps.
- Actioner can reassign the request to other people to action the request.

Entities:
- User
- Employee
- Approver
- Request
- RequestType

User Aggregate:
- User
    - Properties
        - Id
        - Name
        - EmailAddress (ValueObject)
        - EmployeeId (null by default)
    - Methods
        - CreateEmployeeProfile(Division, Department, Section, Role, DirectManager) (Creates Domain Event)
        - CreateApproverProfile(Id) (Creates Domain Event)
        - RemoveUser(this) (Creates Domain Event)

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

