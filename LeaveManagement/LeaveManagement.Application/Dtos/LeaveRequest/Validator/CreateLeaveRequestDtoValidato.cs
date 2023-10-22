using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;

namespace LeaveManagement.Application.Dtos.LeaveRequest.Validator
{
    public class CreateLeaveRequestDtoValidato : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestDtoValidato(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(v => v.StartDate)
                .LessThan(s => s.EndDate).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

            RuleFor(v => v.EndDate)
                .GreaterThan(e => e.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

            RuleFor(v => v.LeaveTypeId)
                .NotNull().WithMessage("Leave type is required.")
                .MustAsync(async (id, token) =>
                {
                    var isLeaverequestExist = await _leaveRequestRepository.Exists(id);
                    return !isLeaverequestExist;
                }).WithMessage("{PropertyName} dose not exist");

        }
    }
}
