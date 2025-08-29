using EmployeeAppV3.Web.Models;
using System.Threading;

namespace EmployeeAppV3.Web.Services;

public class EmployeeService
{
    static List<Employee> employees = new List<Employee>([
        new Employee{Id = 1, Name = "Christofer", Email = "Koffe@internet.se", PunchedIn = false},
        new Employee{Id = 3, Name = "Viktor", Email = "Viktor@internet.se", PunchedIn = false},
        new Employee{Id = 2, Name = "Evelina", Email = "Evelina@internet.se", PunchedIn = false}
        ]);

    public Employee[] GetAllEmployees() => employees.OrderBy(x => x.Id).ToArray();

    public Employee GetEmployeeById(int id) => employees.Single(x => x.Id == id);

    public void AddTime(int id, decimal start, decimal stop)
    {
        foreach (var anställd in employees)
        {
            if (anställd.Id == id)
            {
                if (start != 0)
                {
                    anställd.Start = start;
                    anställd.Stop = 0;
                    anställd.PunchedIn = true;
                }
                else if (stop != 0)
                {
                    anställd.Stop = stop;
                    anställd.Start = 0;
                    anställd.PunchedIn = false;
                }
            }
        }
    }

    public void CreateEmployee(Employee employee)
    {
        employee.Id = employees.Count() == 0 ? 1 : employees.Max(x => x.Id) + 1;

        employees.Add(employee);
    }

}
