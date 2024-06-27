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
    public class LeaveTypeRepository : GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {

        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
            
        }
    }
}
