using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid LeaveTypeId { get; set; }
        public string? RequestComments { get; set; }
        public bool Cancelled { get; set; }
    }
}
