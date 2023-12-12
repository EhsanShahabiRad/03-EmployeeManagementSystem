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

            reporter.SortByName(employees);
            Console.WriteLine("======================================================================");

            reporter.SortByNameDescending(employees);
            Console.WriteLine("======================================================================");

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




        }
    }
}