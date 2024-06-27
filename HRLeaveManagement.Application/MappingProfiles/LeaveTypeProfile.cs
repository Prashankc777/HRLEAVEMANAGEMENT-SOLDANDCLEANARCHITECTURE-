using AutoMapper;
using HRLeaveManagemnetDomain;
using HRLeaveManagement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Feature.LeaveType.Queries.GetLeaveTypeDetails;

namespace HRLeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>().ReverseMap();
        }
    }
}
