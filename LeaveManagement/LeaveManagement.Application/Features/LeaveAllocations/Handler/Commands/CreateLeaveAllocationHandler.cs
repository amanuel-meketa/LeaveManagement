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
        private readonly IMapper _mapper;

        public CreateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateLeaveAllocation request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validatorResult = await validator.ValidateAsync(request.leaveAllocationDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
