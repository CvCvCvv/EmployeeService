using EmployeeService.Commands;
using EmployeeService.DTOs;
using EmployeeService.Queries;
using Hackathon.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class EmployeeController : APIv1Conntroller
    {
        private readonly IEmployeeQueries _employeeQueries;
        private readonly IEmployeeCommands _employeeCommands;
        public EmployeeController(IEmployeeQueries employeeQueries, IEmployeeCommands employeeCommands)
        {
            _employeeQueries = employeeQueries;
            _employeeCommands = employeeCommands;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeCreateDto employeeCreateDto)
        {
            var result = await _employeeCommands.CreateEmployeeAsync(employeeCreateDto);

            return new JsonResult(new { id = result });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(EmployeeGetDto employeeGetDto)
        {
            await _employeeCommands.DeleteEmployeeAsync(employeeGetDto);

            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EmployeeEditDto employeeEditDto)
        {
            await _employeeCommands.EditEmployeeAsync(employeeEditDto);

            return Ok();
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(EmployeeGetDto employeeGetDto)
        {
            var result = await _employeeQueries.GetEmployeeByIdAsync(employeeGetDto);

            return new JsonResult(result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(EmployeeFilterDto employeeFilterDto)
        {
            var result = await _employeeQueries.GetFilteredEmployeeAsync(employeeFilterDto);

            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeQueries.GetAllEmployeeAsync();

            return new JsonResult(result);
        }

    }
}
