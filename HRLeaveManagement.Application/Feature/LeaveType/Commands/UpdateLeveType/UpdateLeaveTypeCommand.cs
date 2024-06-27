using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Commands.UpdateLeveType
{
    internal class UpdateLeaveTypeCommand : IRequest<Unit> // unit means void 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
