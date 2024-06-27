using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
   public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;

    
}
