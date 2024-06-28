using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persisrtance.DatabaseContext;
using HRLeaveManagemnetDomain;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persisrtance.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
            
        }

        public async Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var data = await _context.LeaveAllocations.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            return await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public async Task<bool> AllocationExits(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations
                .AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);

        }

        public async Task AddAllocation(List<LeaveAllocation> leaveAllocations)
        {
            await _context.AddRangeAsync(leaveAllocations);
            await _context.SaveChangesAsync();
        }

        public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q =>
                q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId) ?? new LeaveAllocation();
        }
    }
}
