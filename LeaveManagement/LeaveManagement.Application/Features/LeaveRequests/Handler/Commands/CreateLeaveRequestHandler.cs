using AutoMapper;
using LeaveManagement.Application.Contracts.Infrastructure;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveRequest.Validator;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequest, Guid>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _Mapper;
        private readonly IEmailSenderService _emailService1;

        public CreateLeaveRequestHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            IEmailSenderService emailService)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _Mapper = mapper;
            _emailService1 = emailService;
        }

        public async Task<Guid> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validatorResult = await validator.ValidateAsync(request.leaveRequestDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveRequest = _Mapper.Map<LeaveRequest>(request.leaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
                
            return leaveRequest.Id;
        }
    }
}
