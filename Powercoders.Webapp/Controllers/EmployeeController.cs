using Microsoft.AspNetCore.Mvc;
using Powercoders.Webapp.Models;

namespace Powercoders.Webapp.Controllers;

public class EmployeeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(new Employee[]
        {
            new()
            {
                Firstname = "Lukas",
                Lastname = "Tanner",
                Email = "lukas.tanner@example.com"
            },
            new()
            {
                Firstname = "Lukas",
                Lastname = "Tanner",
                Email = "lukas.tanner@example.com"
            }
        });
    }
}