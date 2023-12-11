using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystem
{
    internal class EmployeeEditor
    {
        public delegate void EmployeeEditHandler(object source, EventArgs args);
        public event EmployeeEditHandler EmployeeEdited;
       
        
        public IEmployee EditEmployee(IEmployee employee , string Name, decimal SalaryPerHour, int Experience)
        {
            Console.WriteLine("Employee is being Updated.......");
            employee.Name = Name;
            employee.SalaryPerHour = SalaryPerHour;
            employee.Experience = Experience;
            Thread.Sleep(3000);
            OnEmployeeEdited();
            return employee;
        }

        protected virtual void OnEmployeeEdited()
        {
            if (EmployeeEdited != null)
            {
                EmployeeEdited(this, EventArgs.Empty);
            }

        }
    }
}
