using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persisrtance.DatabaseContext;
using HRLeaveManagemnetDomain;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persisrtance.Repository;

public class LeaveRequestRepository :  GenericRepository<LeaveType> , ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {

    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
         var data = await _context.LeaveRequests.Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
         return data ?? new LeaveRequest();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestDetails()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
             .ToListAsync();
        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        List<LeaveRequest> leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .Where(q => q.RequestingEmployeeId == userId)
            .ToListAsync();
        return leaveRequests;
    }
}