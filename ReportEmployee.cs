using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class ReportEmployee
    {
        public void SortByName (List<IEmployee> employees)
        {
            var result = employees.OrderBy(x => x.Name).ToList();


            foreach (var item in result)
            {
                Console.WriteLine($"Name:{item.Name}   SalaryPerHour:{item.SalaryPerHour}   Experience:{item.Experience}");
            }
        }

        public void SortByNameDescending(List<IEmployee> employees)
        {
            var result = employees.OrderByDescending(x => x.Name).ToList();


            foreach (var item in result)
            {
                Console.WriteLine($"Name:{item.Name}   SalaryPerHour:{item.SalaryPerHour}   Experience:{item.Experience}");
            }
        }

        public void FilterSalaryAbove(List<IEmployee> employees , decimal value)
        {
            var result = employees.Where(x => x.CalculateSalary() > value).ToList();

            Console.WriteLine($"Above {value}:");
            foreach (var item in result)
            {
                
                Console.WriteLine($"Name:{item.Name}   SalaryPerHour:{item.SalaryPerHour}   Experience:{item.Experience}");
            }
        }

        public void FilterSalaryBelow(List<IEmployee> employees , decimal value)
        {

            var result = employees.Where(x => x.CalculateSalary() < value).ToList();

            Console.WriteLine($"Below {value}:");
            foreach (var item in result)
            {

                Console.WriteLine($"Name:{item.Name}   SalaryPerHour:{item.SalaryPerHour}   Experience:{item.Experience}");
            }
        }

        public void HighestPaid(List<IEmployee> employees)
        {

            var result = employees.MaxBy(x => x.CalculateSalary());

            Console.WriteLine($"Highest Paid Employee: {result?.Name}");
            
        }

    }
}
