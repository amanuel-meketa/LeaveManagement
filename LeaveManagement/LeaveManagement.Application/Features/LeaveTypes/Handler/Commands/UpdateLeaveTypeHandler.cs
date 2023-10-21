using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handler.Commands
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveType, Guid>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(UpdateLeaveType request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);
            await _leaveTypeRepository.Update(leaveType);

            return leaveType.Id;
        }
    }
}
