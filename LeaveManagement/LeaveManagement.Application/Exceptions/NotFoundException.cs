namespace LeaveManagement.Application.Exceptions
{
    internal class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} {key} not found")
        {
            
        }
    }
}
