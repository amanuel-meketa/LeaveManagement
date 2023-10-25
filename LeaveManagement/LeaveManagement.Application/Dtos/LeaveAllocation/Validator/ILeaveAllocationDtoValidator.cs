using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;

namespace LeaveManagement.Application.Dtos.LeaveAllocation.Validator
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(v => v.LeaveTypeId)
                .NotNull().WithMessage("Leave type is required.");

            RuleFor(v => v.NumberOfDays)
                .LessThan(1).WithMessage("{PropertyName} must be atleast 1.")
                .GreaterThan(100).WithMessage("{PropertyName} must be atleast 100.");            

            RuleFor(v => v.LeaveTypeId)
                 .NotNull().WithMessage("Leave type is required.")
                 .MustAsync(async (id, token) =>
                 {
                     var isLeaveAllocationExist = await _leaveAllocationRepository.Exists(id);
                     return !isLeaveAllocationExist;
                 }).WithMessage("{PropertyName} dose not exist");
        }
    }
}
