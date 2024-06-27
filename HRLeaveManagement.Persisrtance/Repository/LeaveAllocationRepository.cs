using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persisrtance.DatabaseContext;
using HRLeaveManagemnetDomain;

namespace HRLeaveManagement.Persisrtance.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
            
        }
    }
}
