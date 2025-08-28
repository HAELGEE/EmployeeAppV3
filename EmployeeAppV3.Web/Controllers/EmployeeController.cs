using EmployeeAppV3.Web.Models;
using EmployeeAppV3.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppV3.Web.Controllers;
public class EmployeeController : Controller
{
    EmployeeService employeeService = new EmployeeService();

    [Route("")]
    public IActionResult Index()
    {
        return View(employeeService.GetAllEmployees());
    }

    [HttpGet("Details/{id}")]
    public IActionResult Details(int id)
    {
        return View(employeeService.GetEmployeeById(id));
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost("Create")]
    public IActionResult Create(Employee employee)
    {
        if(!ModelState.IsValid) 
        return View();

        employeeService.CreateEmployee(employee);
        return RedirectToAction(nameof(Index));
    }
}
