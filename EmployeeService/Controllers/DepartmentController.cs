using EmployeeService.Commands;
using EmployeeService.DTOs;
using EmployeeService.Queries;
using Hackathon.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class DepartmentController : APIv1Conntroller
    {
        private readonly IDepartmentCommands _departmentCommands;
        private readonly IDepartmentQueries _departmentQueries;
        public DepartmentController(IDepartmentCommands departmentCommands, IDepartmentQueries departmentQueries)
        {
            _departmentCommands = departmentCommands;
            _departmentQueries = departmentQueries;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto)
        {
            var result = await _departmentCommands.CreateDepartmentAsync(departmentCreateDto);

            return new JsonResult(new { id = result });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DepartmentGetDto departmentGetDto)
        {
            await _departmentCommands.DeleteDepartmentAsync(departmentGetDto);

            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(DepartmentEditDto departmentEditDto)
        {
            await _departmentCommands.EditDepartmentAsync(departmentEditDto);

            return Ok();
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(DepartmentGetDto departmentGetDto)
        {
            var result = await _departmentQueries.GetDepartmentByIdAsync(departmentGetDto);

            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentQueries.GetAllDepartmentAsync();

            return new JsonResult(result);
        }
    }
}
