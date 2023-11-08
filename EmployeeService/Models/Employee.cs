namespace EmployeeService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public DateOnly DateOfEmployment { get; set; }
        public double Tariff { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;
    }
}
