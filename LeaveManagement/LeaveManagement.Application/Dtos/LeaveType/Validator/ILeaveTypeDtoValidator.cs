using FluentValidation;

namespace LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(v => v.Name)
                .Empty().WithMessage("{PropertyName} is requierd.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} charctors.");

            RuleFor(v => v.DefaultDays)
                .Empty().WithMessage("{PropertyName} is requierd.")
                .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        }
    }
}
