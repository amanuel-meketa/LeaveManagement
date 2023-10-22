
namespace LeaveManagement.Application.Dtos.LeaveType
{
    public class CreateLeaveTypeDto : ILeaveTypeDto
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
