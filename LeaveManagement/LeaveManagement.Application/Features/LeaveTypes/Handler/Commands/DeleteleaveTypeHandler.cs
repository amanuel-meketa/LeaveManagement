using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handler.Commands
{
    public class DeleteleaveTypeHandler : IRequestHandler<DeleteleaveType>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteleaveTypeHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteleaveType request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveTypes), request.Id);

            await _leaveTypeRepository.Delete(leaveType);

            return Unit.Value;
        }
    }
}
