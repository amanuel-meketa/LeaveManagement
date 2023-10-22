using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using MediatR;
namespace LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            await _leaveRequestRepository.Delete(leaveRequest);

            return Unit.Value;
        }
    }
}
