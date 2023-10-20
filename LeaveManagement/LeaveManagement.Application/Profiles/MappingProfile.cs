using AutoMapper;
using LeaveManagement.Application.Dtos.LeaveAllocation;
using LeaveManagement.Application.Dtos.LeaveRequest;
using LeaveManagement.Application.Dtos.LeaveType;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
