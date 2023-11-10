using EmployeeService.Models;

namespace EmployeeService.DTOs
{
    public class EmployeeEditDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public double Tariff { get; set; }
        public int DepartmentId { get; set; }
        public int JobPostId { get; set; }
    }
}
