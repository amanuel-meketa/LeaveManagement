using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos.LeaveType
{
    public class LeaveTypeDto : BaseDto
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
