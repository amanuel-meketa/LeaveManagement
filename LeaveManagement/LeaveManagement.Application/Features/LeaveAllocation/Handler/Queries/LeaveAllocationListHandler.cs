using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos;
using LeaveManagement.Application.Features.LeaveAllocation.Request.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Handler.Queries
{
    public class LeaveAllocationListHandler : IRequestHandler<LeaveAllocationList, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(LeaveAllocationList request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetAll();

            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}
