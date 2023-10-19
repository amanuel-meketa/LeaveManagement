using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos
{
    public class LeaveTypeDto : BaseDto
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
