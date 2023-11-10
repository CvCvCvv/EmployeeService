namespace EmployeeService.DTOs
{
    public class JobPostEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double SalaryIncrement { get; set; }
    }
}
