using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveType;
using LeaveManagement.Application.Features.LeaveType.Request.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Handler.Queries
{
    public class GetLeaveTypeDetailHandler : IRequestHandler<GetLeaveTypeDetail, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetail request, CancellationToken cancellationToken)
        {
            var LeaveType = await _leaveTypeRepository.GetLeaveTypeDetail(request.Id);

            return _mapper.Map<LeaveTypeDto>(LeaveType);
        }
    }
}
