using EmployeeAppV3.Web.Models;

namespace EmployeeAppV3.Web.Services;

public class EmployeeService
{
    static List<Employee> employees = new List<Employee>([
        new Employee{Id = 1, Name = "Christofer", Email = "Koffe@internet.se"},
        new Employee{Id = 3, Name = "Viktor", Email = "Viktor@internet.se"},
        new Employee{Id = 2, Name = "Evelina", Email = "Evelina@internet.se"}
        ]);

    public Employee[] GetAllEmployees() => employees.OrderBy(x => x.Id).ToArray();

    public Employee GetEmployeeById(int id) => employees.Single(x => x.Id == id);

    public void CreateEmployee(Employee employee)
    {
        employee.Id = employees.Count() == 0 ? 1 : employees.Max(x => x.Id) + 1;

        employees.Add(employee);
    }

}
