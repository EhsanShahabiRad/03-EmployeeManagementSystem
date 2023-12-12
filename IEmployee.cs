using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public interface IEmployee
    {
       
        public string Name { get; set; }
        public decimal SalaryPerHour { get; set; }
        public int Experience { get; set; }
        public int Type { get; set; }

        decimal CalculateSalary();
       
        void DisplayDetails();

        
        
        
    }
}
