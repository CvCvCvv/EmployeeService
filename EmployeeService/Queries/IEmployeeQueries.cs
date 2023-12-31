﻿using EmployeeService.DTOs;
using EmployeeService.Models;

namespace EmployeeService.Queries
{
    public interface IEmployeeQueries
    {
        public Task<EmployeeDto> GetEmployeeByIdAsync(EmployeeGetDto employeeGetDto);
        public Task<List<EmployeeDto>> GetAllEmployeeAsync();
        public Task<EmployeeFilteredDto> GetFilteredEmployeeAsync(EmployeeFilterDto employeeFilterDto);
        public bool IsExistsId(int id);
    }
}
