using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await _leaveRequestRepository.Delete(leaveRequest);

            return Unit.Value;
        }
    }
}
