namespace EmployeeManagementSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            XmlManager xmlManager = new XmlManager();
            xmlManager.GenerateXML();
            List<IEmployee> employees = xmlManager.RetrieveEmployeeFromXML();
            ReportEmployee reporter = new ReportEmployee();

            Console.WriteLine("Sorting Employees By Name:");
            reporter.SortByName(employees);
            Console.WriteLine("======================================================================");

            Console.WriteLine("Sorting Employees By Name Descending:");
            reporter.SortByNameDescending(employees);
            Console.WriteLine("======================================================================");

            Console.WriteLine("Filter Employees by Salary");
            reporter.FilterSalaryBelow(employees, 1000);
            
            reporter.FilterSalaryAbove(employees, 1000);
            Console.WriteLine("======================================================================");

            reporter.HighestPaid(employees);
            Console.WriteLine("======================================================================");


            MessageService messageService = new MessageService();
          
            var EmployeeToEdit = employees[1];

            xmlManager.EmployeeEdited += messageService.onEmployeeEdited;
            xmlManager.UpdateEmployee("Kaveh", 5, 18, 1);
           
             employees.Clear();
            employees = xmlManager.RetrieveEmployeeFromXML();


            reporter.SortByName(employees);
            Console.WriteLine("======================================================================");


            Console.ReadKey();

        }
    }
}