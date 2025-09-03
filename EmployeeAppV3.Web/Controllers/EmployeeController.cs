using EmployeeAppV3.Web.Models;
using EmployeeAppV3.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EmployeeAppV3.Web.Controllers;
public class EmployeeController : Controller
{
    private readonly EmployeeService _employeeService;
    EmployeeViewModel viewModel = new EmployeeViewModel();


    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    //[Route("")]
    public IActionResult Index()
    {
        viewModel.EmployeeService = _employeeService;
        return View(viewModel);
    }

    // Info om anställd
    //[HttpGet("Details/{id}")]
    public IActionResult Details(int id)
    {
        ViewBag.Id = id;

        viewModel.EmployeeService = _employeeService;
        return View(viewModel);
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
        viewModel.EmployeeService = _employeeService;
        if (!ModelState.IsValid)
            return View();        

        _employeeService.CreateEmployee(employee);
        return RedirectToAction(nameof(Index));
    }

    // Stämpel Klocka
    //[HttpGet("Punchclock")]
    public IActionResult Punchclock(int? id)
    {
        ViewBag.SelectedId = id;
                
        viewModel.EmployeeService = _employeeService;
        return View(viewModel);
    }

    [HttpPost("Punchclock")]
    public IActionResult Punchclock(int Id, bool PunchedIn)
    {
        _employeeService.AddTime(Id, PunchedIn);

        return RedirectToAction(nameof(Index));
    }

    // Lön sida
    //[HttpGet("Salary/{id}")]
    public IActionResult Salary(int id)
    {
        ViewBag.Id = id;

        viewModel.EmployeeService = _employeeService;
        return View(viewModel);        
    }
}
