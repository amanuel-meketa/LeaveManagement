using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveAllocation.Validator;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Commands;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handler.Commands
{
    public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocation, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocation request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator();
            var result = await validator.ValidateAsync(request.updatellocationDto);

            if (!result.IsValid)
                throw new Exception();

            var leaveAllocation = await _leaveAllocationRepository.Get(request.updatellocationDto.Id);
            _mapper.Map(request.updatellocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
