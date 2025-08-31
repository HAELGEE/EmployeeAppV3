using EmployeeAppV3.Web.Models;
using EmployeeAppV3.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
        var employee = employeeService.GetEmployeeById(id);

        if (employee != null)
            return View(employee);
        else
            return RedirectToAction(nameof(Index));
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
        if (!ModelState.IsValid)
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
    public IActionResult Punchclock(int Id, bool PunchedIn)
    {
        employeeService.AddTime(Id, PunchedIn);

        return RedirectToAction(nameof(Index));
    }

    // Lön sida
    [HttpGet("Salary/{id}")]
    public IActionResult Salary(int id)
    {
        Employee employee = employeeService.GetEmployeeById(id);

        employeeService.MonthSalaryAdd(employee);

        return View(employee);
    }

    //[HttpPost("Salary")]
    //public IActionResult Salary(int Id, TimeOnly Start, TimeOnly Stop)
    //{
    //    return RedirectToAction(nameof(Index));
    //}
}
