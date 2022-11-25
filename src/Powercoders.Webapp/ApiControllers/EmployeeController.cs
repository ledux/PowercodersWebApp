using Microsoft.AspNetCore.Mvc;
using Powercoders.Webapp.Models;

namespace Powercoders.Webapp.ApiControllers;

[ApiController]
[Route("/api/[Controller]")]
public class EmployeeController : ControllerBase
{
    private static readonly IList<Employee> EmployeeRepository = new List<Employee>
    {
        new(1, "Lukas", "Tanner", "lukas.tanner@example.com"),
        new(2, "Eric", "Idle", "eric.idle@example.com")
    };
    
    public IActionResult Get()
    {
        return Ok(new EmployeeList(EmployeeRepository));
    }
}