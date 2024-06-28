using HRLeaveManagemnetDomain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveType>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    Task<List<LeaveRequest>> GetLeaveRequestDetails();
    Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);

}