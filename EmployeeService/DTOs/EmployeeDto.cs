namespace EmployeeService.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public double Tariff { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string JobPost { get; set; } = null!;
        public int JobPostId { get; set; }
    }
}
