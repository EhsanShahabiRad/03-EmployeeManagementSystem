using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementSystem
{
    public class XmlManager
    {
        
        public void GenerateXML()
        {
            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new FullTimeEmployee("Reza", 25, 15));
            employees.Add(new FullTimeEmployee("Kaveh", 12, 3));
            employees.Add(new PartTimeEmployee("Ehsan", 15, 2));
            employees.Add(new PartTimeEmployee("Eshghe Kaveh", 9, 1));

            String filePath = Path.Combine("../../../", "Employees.xml");
            //if (!File.Exists(filePath))
            //{
                XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Employees",
                    //new XElement("Employee",
                    // new XElement("NAME", "..."),
                    //    new XElement("SalaryPerHour", "..."),
                    //    new XElement("Experience", "...")
                    from employee in employees
                    select new XElement("Employee",
                                new XElement("Name", employee.Name),
                                new XElement("SalaryPerHour", employee.SalaryPerHour),
                                new XElement("Type", employee.Type),
                                new XElement("Experience", employee.Experience)) )); ;

                xml.Save(filePath);
            //}
            
           
           
        }

        public List<IEmployee> RetrieveEmployeeFromXML()
        {
            //List<IEmployee> employees = new List<IEmployee>();


            //employees = from Employee in XDocument.Load(Path.Combine("../../../", "Employees.xml")).Descendants("Employee")

            //            select employees.Add({namme })

            //where(a=>a.type== 1 && a.id== id).select()

            XDocument doc = XDocument.Load(Path.Combine("../../../", "Employees.xml"));

            List<IEmployee> employees = doc.Root
            .Elements("Employee")
            .Select(e =>
            {
                int type = int.Parse(e.Element("Type").Value);
                IEmployee employee;

                if (type == 1)
                {
                    employee = new FullTimeEmployee(
                        e.Element("Name").Value,
                        decimal.Parse(e.Element("SalaryPerHour").Value),
                        int.Parse(e.Element("Experience").Value)

                    );
                }
                else
                {
                    employee = new PartTimeEmployee(
                        e.Element("Name").Value,
                        decimal.Parse(e.Element("SalaryPerHour").Value),
                        int.Parse(e.Element("Experience").Value)

                    );
                }



                return employee;
            })
            .ToList();

            return employees;



        }

        public delegate void EmployeeEditHandler(object source, EventArgs args);
        public event EmployeeEditHandler EmployeeEdited;

        public void UpdateEmployee(string employeeName, int experience, decimal salaryPerHour,int type)
        {
            Console.WriteLine("Employee is being Updated");

            XDocument doc = XDocument.Load(Path.Combine("../../../", "Employees.xml"));

            var employeeElement = doc.Root.Elements("Employee")
                .FirstOrDefault(e => e.Element("Name")?.Value == employeeName);

            if (employeeElement != null)
            {
               
                employeeElement.Element("Experience").Value = experience.ToString();
                employeeElement.Element("SalaryPerHour").Value = salaryPerHour.ToString();
                employeeElement.Element("Type").Value = type.ToString();
               
                doc.Save(Path.Combine("../../../", "Employees.xml"));
               
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");

                OnEmployeeEdited();
            }
            else
            {
                Console.WriteLine($"Employee {employeeName} not found.");
            }
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

