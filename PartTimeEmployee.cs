using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class PartTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public decimal SalaryPerHour { get; set; }
        public int Experience { get; set; }


        public PartTimeEmployee(string name, decimal salaryPerHour, int experience)
        {
            Name = name;
            SalaryPerHour = salaryPerHour;
            Experience = experience;
        }


        public decimal CalculateSalary()
        {

            decimal salary = (90 * SalaryPerHour) * (1 + Experience / 100);
            return salary;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee Type: PartTime");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"SalaryPerHour: {SalaryPerHour}");
            Console.WriteLine($"Total Salary ......");
        }
    }
}
