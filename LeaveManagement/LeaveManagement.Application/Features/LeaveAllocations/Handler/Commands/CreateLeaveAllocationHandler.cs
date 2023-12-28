using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveAllocation.Validator;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Commands;
using LeaveManagement.Domain;
using MediatR;
using ValidationException = LeaveManagement.Application.Exceptions.ValidationException;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handler.Commands
{
    public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocation, Guid>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateLeaveAllocation request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.leaveAllocationDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveRequest = _mapper.Map<LeaveAllocation>(request.leaveAllocationDto);
            leaveRequest = await _leaveAllocationRepository.Add(leaveRequest);

            return leaveRequest.Id;
        }
    }
}
