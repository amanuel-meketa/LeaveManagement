using AutoMapper;
using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveAllocation.Validator;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Commands;
using LeaveManagement.Domain;
using MediatR;

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
            var validator = new CreateLeaveAllocationDtoValidator();
            var result = await validator.ValidateAsync(request.leaveAllocationDto);

            if (!result.IsValid)
                throw new Exception();

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
