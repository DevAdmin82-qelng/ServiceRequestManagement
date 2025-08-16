using SRM.Domain.Common.Models;

namespace SRM.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    public Admin(Guid? id = null) : base(id ?? Guid.NewGuid())
    {
    } 
    
    public Admin() {}

}
