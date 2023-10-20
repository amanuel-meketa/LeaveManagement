using LeaveManagement.Application.Dtos.Common;
using LeaveManagement.Application.Dtos.LeaveType;

namespace LeaveManagement.Application.Dtos.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public string? RequestingEmployeeId { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
