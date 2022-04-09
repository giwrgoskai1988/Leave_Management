using AutoMapper;
using LM.Application.DTOs.LeaveAllocation;
using LM.Application.DTOs.LeaveRequest;
using LM.Application.DTOs.LeaveType;
using LM.Domain;

namespace LM.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
