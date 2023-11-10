using Hackathon.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class SmokeController : APIv1Conntroller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new { message= "ok"});
        }
    }
}