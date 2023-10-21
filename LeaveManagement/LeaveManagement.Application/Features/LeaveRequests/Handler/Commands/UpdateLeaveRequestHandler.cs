using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequest request, CancellationToken cancellationToken)
        {

            var leaveRequest = await _leaveRequestRepository.Get(request.updateLeaveRequestDto.Id);
            _mapper.Map(request.updateLeaveRequestDto, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);

            return Unit.Value;     
        }
    }
}
