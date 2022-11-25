using Microsoft.AspNetCore.Mvc;
using Powercoders.Webapp.Models;

namespace Powercoders.Webapp.Controllers;

public class EmployeeController : Controller
{
    private static readonly IList<Employee> EmployeeRepository = new List<Employee>
    {
        new(1, "Lukas", "Tanner", "lukas.tanner@example.com"),
        new(2, "Eric", "Idle", "eric.idle@example.com")
    };

    private static readonly IList<string> EmailRepository = new List<string>
    {
        "lukas.tanner@example.com",
        "eric.idle@example.com"
    };
    
    // GET
    public IActionResult Index()
    {
        return View(EmployeeRepository);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        var employeeEmail = $"{employee.Firstname.ToLower()}.{employee.Lastname.ToLower()}@example.com";
        if (EmailRepository.Contains(employeeEmail))
        {
            return View("Error", new ErrorViewModel());
        }

        var nextId = EmployeeRepository.OrderBy(e => e.Id).Last().Id + 1;
        var createdEmployee = employee with{ Email = employeeEmail, Id = nextId };

        EmailRepository.Add(employeeEmail);
        EmployeeRepository.Add(createdEmployee);
        
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Edit(uint id)
    {
        var employee = EmployeeRepository.SingleOrDefault(e => e.Id == id);
        if (employee is null)
        {
            return View("Error", new ErrorViewModel());
        }

        return View(employee);
    }
    
    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        var employeeEmail = $"{employee.Firstname.ToLower()}.{employee.Lastname.ToLower()}@example.com";
        if (EmailRepository.Contains(employeeEmail))
        {
            return View("Error", new ErrorViewModel());
        }

        var employeeToUpdate = EmployeeRepository.SingleOrDefault(e => e.Id == employee.Id);
        if (employeeToUpdate is not null)
        {
            EmployeeRepository.Remove(employeeToUpdate);
            EmailRepository.Remove(employeeToUpdate.Email);
        }

        var updatedEmployee = employee with { Email = employeeEmail };
        
        EmailRepository.Add(employeeEmail);
        EmployeeRepository.Add(updatedEmployee);
        
        return RedirectToAction("Index");
    }

    public IActionResult Details(uint employeeId)
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete(uint employeeId)
    {
        throw new NotImplementedException();
    }
}