
using SRM.Domain.Common.Enums;
using SRM.Domain.Common.Models;
using SRM.Domain.RequestAggregate.RequestDataTypes;

namespace SRM.Domain.RequestAggregate;

public class Request: AggregateRoot
{
   public Guid EmployeeId;
    
   public RequestType RequestType { get; }

    // TODO: Implement RequestDataFactory and RequestData ValueObjects for each type.
   public RequestData? RequestData { get; private set; } 

    // TODO: Implement Approver and ApproverMatrix child entities to genereate dynamic approver queue.
    // Possibly have a configuration file or store in DB. 
    // Default behaviour may be check the employee object for their DirectManager.
    // If there is a specific owner of the request type they will also be added in the matrix.
    // Need time to thing this one through.
   public Queue<Approver>? _approverQueue;


}
