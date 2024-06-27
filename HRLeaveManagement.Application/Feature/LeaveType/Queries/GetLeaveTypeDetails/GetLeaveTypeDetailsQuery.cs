using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailDto>;


}
