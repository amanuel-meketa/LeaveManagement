using FluentValidation;

namespace LeaveManagement.Application.Dtos.LeaveAllocation.Validator
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        public UpdateLeaveAllocationDtoValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(v => v.LeaveTypeId)
               .NotNull().WithMessage("Leave type is required.");

            RuleFor(v => v.NumberOfDays)
                .LessThan(1).WithMessage("{PropertyName} must be atleast 1.")
                .GreaterThan(100).WithMessage("{PropertyName} must be atleast 100.");
                
            RuleFor(v => v.NumberOfDays)
                .LessThan(1).WithMessage("{PropertyName}");
        }
    }
}
