using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Request.Commands
{
    public class DeleteleaveType : IRequest
    {
        public Guid Id { get; set; }
    }
}
