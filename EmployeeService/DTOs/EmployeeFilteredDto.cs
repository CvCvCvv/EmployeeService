namespace EmployeeService.DTOs
{
    public class EmployeeFilteredDto
    {
        public int Pages { get; set; }
        public List<EmployeeDto> employees { get; set; } = new();
    }
}
