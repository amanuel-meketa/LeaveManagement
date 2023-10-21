﻿using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handler.Commands
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveType, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveType request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.leaveTypeDto.Id);

            _mapper.Map(request.leaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}