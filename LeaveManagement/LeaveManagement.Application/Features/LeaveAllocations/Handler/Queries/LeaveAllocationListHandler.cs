using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handler.Queries
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
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationDetail();

            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}
