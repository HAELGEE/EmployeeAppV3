using EmployeeAppV3.Web.Models;
using System.Threading;

namespace EmployeeAppV3.Web.Services;

public class EmployeeService
{
    static List<Employee> employees = new List<Employee>([
        new Employee{Id = 1, Name = "Christofer", Email = "Koffe@internet.se", PunchedIn = null, Salary = 1337},
        new Employee{Id = 3, Name = "Viktor", Email = "Viktor@internet.se", PunchedIn = null, Salary = 13},
        new Employee{Id = 2, Name = "Evelina", Email = "Evelina@internet.se", PunchedIn = null, Salary = 37}
        ]);

    public Employee[] GetAllEmployees() => employees.OrderBy(x => x.Id).ToArray();

    public Employee GetEmployeeById(int id) => employees.SingleOrDefault(x => x.Id == id); // Skickar null om jag inte får något ID

    public void AddTime(int id, bool punchedIn)
    {
        foreach (var anställd in employees)
        {
            if (anställd.Id == id)
            {

                if (punchedIn)
                {
                    anställd.PunchedIn = punchedIn;

                    anställd.DayStamps!.Add(new Time { Started = DateTime.Now, Date = DateOnly.FromDateTime(DateTime.Now) });

                }
                else if (!punchedIn)
                {
                    anställd.PunchedIn = punchedIn;

                    foreach (var Time in anställd.DayStamps!)
                    {
                        int count = anställd.DayStamps.Count() - 1;
                        anställd.DayStamps[count].Stopped = DateTime.Now;
                    }
                }
            }
        }
    }

    public void CreateEmployee(Employee employee)
    {
        employee.Id = employees.Count() == 0 ? 1 : employees.Max(x => x.Id) + 1;

        employees.Add(employee);
    }

    public void MonthSalaryAdd(Employee employee)
    {
        decimal time = 0;

        foreach (var tid in employee.DayStamps!)
        {
            if (tid.Stopped.HasValue)
            {

                char[] chars = tid.Started.ToShortTimeString().ToCharArray();
                chars![2] = ',';
                decimal newStart = Convert.ToDecimal(new string(chars))!;

                char[] chars2 = tid.Stopped.Value.ToShortTimeString().ToCharArray();
                chars2![2] = ',';
                decimal newStop = Convert.ToDecimal(new string(chars))!;

                time = newStop - newStart;



            }
        }

        if (time > 0)
        {
            foreach (var employed in employees)
            {
                if (employed.Id == employee.Id)
                {
                    employed.WorkedTime = time;
                    employed.Salary += Convert.ToInt32(employed.WorkedTime * 1200);
                }
            }
        }
    }

}
