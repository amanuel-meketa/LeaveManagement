using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using MediatR;
using LeaveManagement.Domain;
using LeaveManagement.Application.Dtos.LeaveType.Validator;
using LeaveManagement.Application.Exceptions;

namespace LeaveManagement.Application.Features.LeaveTypes.Handler.Commands
{
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveType, Guid>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeaveType request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.leaveTypeDto);
             
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);
                leaveType = await _leaveTypeRepository.Add(leaveType);

            return leaveType.Id;
        }
    }
}
