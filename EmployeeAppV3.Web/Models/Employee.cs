using System.ComponentModel.DataAnnotations;

namespace EmployeeAppV3.Web.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Ange personens namn", Prompt = "Var god skriv namnet här....")]    
    public string? Name { get; set; }


    [Required]
    [Display(Name = "Ange personens Email", Prompt = "Var god skriv Email här....")]
    [EmailAddress(ErrorMessage = "Måste vara giltig email")]
    public string? Email { get; set; }
    public List<Time>? DayStamps { get; set; } = new List<Time>();
    public bool? PunchedIn { get; set; } = null;
    public int Salary { get; set; }
    public int MonthSalary { get; set; }
    public decimal WorkedTime { get; set; }
}
