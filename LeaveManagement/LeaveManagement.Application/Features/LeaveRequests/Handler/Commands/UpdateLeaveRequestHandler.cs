using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveRequest.Validator;
using LeaveManagement.Application.Exceptions;
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
            var validator = new UpdateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validatorResult = await validator.ValidateAsync(request.updateLeaveRequestDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.updateLeaveRequestDto != null)
            { 
                _mapper.Map(request.updateLeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;     
        }
    }
}
