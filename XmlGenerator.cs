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
    public class XmlGenerator
    {
        
        public void GenerateXML(List<IEmployee> EmployeeList)
        {
           
            String filePath = Path.Combine("../../../", "Employees.xml");
            if (!File.Exists(filePath))
            {
                XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Employees",
                    //new XElement("Employee",
                    // new XElement("NAME", "..."),
                    //    new XElement("SalaryPerHour", "..."),
                    //    new XElement("Experience", "...")
                    from employee in EmployeeList
                    select new XElement("Employee",
                                new XElement("NAme", employee.Name),
                                new XElement("SalaryPerHour", employee.SalaryPerHour),
                                new XElement("Type", employee.Type),
                                new XElement("Experience", employee.Experience)) )); ;

                xml.Save(filePath);
            }
            
           
           
        }
    }
}
