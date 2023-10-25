using FluentValidation;

namespace LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(v => v.Id).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
