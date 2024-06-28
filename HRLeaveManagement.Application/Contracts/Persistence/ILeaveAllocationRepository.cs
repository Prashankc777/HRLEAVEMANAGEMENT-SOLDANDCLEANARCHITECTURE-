using HRLeaveManagemnetDomain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
    Task<bool> AllocationExits(string userId , int leaveTypeId, int period);
    Task AddAllocation(List<LeaveAllocation> leaveAllocations);
    Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);

}