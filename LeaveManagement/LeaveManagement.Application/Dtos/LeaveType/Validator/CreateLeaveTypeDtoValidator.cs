using FluentValidation;

namespace LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(v => v.Name)
                .Empty().WithMessage("{PropertyName} is requierd.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 charctors.");

            RuleFor(v => v.DefaultDays)
                .Empty().WithMessage("{PropertyName} is requierd.")
                .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        }
    }
}
