﻿namespace EmployeeService.Models
{
    public class JobPost
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double SalaryIncrement { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
