using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("{PropertyName} is required.");

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
