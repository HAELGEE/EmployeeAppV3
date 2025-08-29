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

    // Info om anställd
    [HttpGet("Details/{id}")]
    public IActionResult Details(int id)
    {
        return View(employeeService.GetEmployeeById(id));
    }

    // Skapa anställd
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

    // Stämpel Klocka
    [HttpGet("Punchclock")]
    public IActionResult Punchclock(int? id)
    {
        ViewBag.SelectedId = id;
        return View(employeeService.GetAllEmployees());
    }

    [HttpPost("Punchclock")]
    public IActionResult Punchclock(int Id, decimal Start, decimal Stop)
    {          
        employeeService.AddTime(Id, Start, Stop);

        return RedirectToAction(nameof(Index));
    }

    // Lön sida
    [HttpGet("Salary/{id}")]
    public IActionResult Salary(int id)
    {
        return View(employeeService.GetEmployeeById(id));
    }

    [HttpPost("Salary")]
    public IActionResult Salary(int Id, decimal Start, decimal Stop)
    {
        employeeService.AddTime(Id, Start, Stop);

        return RedirectToAction(nameof(Index));
    }
}
