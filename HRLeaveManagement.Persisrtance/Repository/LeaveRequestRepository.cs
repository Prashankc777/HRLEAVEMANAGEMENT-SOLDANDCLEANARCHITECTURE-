using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persisrtance.DatabaseContext;
using HRLeaveManagemnetDomain;

namespace HRLeaveManagement.Persisrtance.Repository;

public class LeaveRequestRepository :  GenericRepository<LeaveType> , ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {

    }
    
}